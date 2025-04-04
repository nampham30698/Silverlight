﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.Infrastructure.Identity;
using Silverlight.Web.Configuration;

namespace Silverlight.Web.Areas.Identity.Pages.Account;

//TODO : replace IMemoryCache by distributed cache if you are in multi-host scenario
public class LogoutModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IAppLogger<LogoutModel> _logger;
    private readonly IMemoryCache _cache;

    public LogoutModel(SignInManager<ApplicationUser> signInManager, IAppLogger<LogoutModel> logger, IMemoryCache cache)
    {
        _signInManager = signInManager;
        _logger = logger;
        _cache = cache;
    }

    public async Task<IActionResult> OnGetAsync(string? returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var userId = _signInManager.Context.User.Claims.First(c => c.Type == ClaimTypes.Name);
        var identityKey = _signInManager.Context.Request.Cookies[ConfigureCookieSettings.IdentifierCookieName];
        _cache.Set($"{userId.Value}:{identityKey}", identityKey, new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(ConfigureCookieSettings.ValidityMinutesPeriod)
        });

        _logger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            return LocalRedirect("/");
        }
    }
}
