using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.Web.Models;
using System.Diagnostics;

namespace Silverlight.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppLogger<HomeController> _appLogger;
        private readonly ICategoryService _categoryService;
        private readonly ITokenClaimsService _tokenClaimsService;

        public HomeController(IAppLogger<HomeController> appLogger, ICategoryService categoryService, ITokenClaimsService tokenClaimsService)
        {
            _appLogger = appLogger;
            _categoryService = categoryService;
            _tokenClaimsService = tokenClaimsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}