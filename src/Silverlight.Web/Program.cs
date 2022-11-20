using Ardalis.ListStartupServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using NLog;
using NLog.Web;
using Silverlight.Infrastructure.Data;
using Silverlight.Infrastructure.Identity;
using Silverlight.Web;
using Silverlight.Web.Autofac;
using Silverlight.Web.Configuration;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    #region snippet_configureservices

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

    // Add Silverlight.Infrastructure Dbconnection
    Silverlight.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);
    builder.Services.AddCoreServices(builder.Configuration);
    builder.Services.AddWebServices(builder.Configuration);

    AutofacConfig.Configure(builder);

    // Add AutoMapper
    builder.Services.AddAutoMapper(typeof(Program));

    // Add memory cache services
    builder.Services.AddMemoryCache();

    // Add ConfigureApplicationCookie
    builder.Services.AddCookieSettings();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Lax;
        });

    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddDefaultUI()
               .AddEntityFrameworkStores<AppIdentityDbContext>()
               .AddDefaultTokenProviders();

    builder.Services.AddRazorPages();

    builder.Services.AddHttpContextAccessor();

    builder.Services.Configure<ServiceConfig>(config =>
    {
        config.Services = new List<ServiceDescriptor>(builder.Services);
        config.Path = "/allservices";
    });

    builder.Services.AddRouting(options =>
    {
        // Replace the type and the name used to refer to it with your own
        // IOutboundParameterTransformer implementation
        options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
    });

    builder.Services.AddMvc(options =>
    {
        options.Conventions.Add(new RouteTokenTransformerConvention(
                 new SlugifyParameterTransformer()));

    });

    #endregion


    #region snippet_configure

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var scopedProvider = scope.ServiceProvider;
        try
        {
            var silverlightDbContext = scopedProvider.GetRequiredService<SilverlightDbContext>();
            await SilverlightDbContextSeed.SeedAsync(silverlightDbContext);

            var userManager = scopedProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var identityContext = scopedProvider.GetRequiredService<AppIdentityDbContext>();
            // Add default user
            await AppIdentityDbContextSeed.SeedAsync(identityContext, userManager, roleManager);
        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "An error occurred seeding the DB.");
        }
    }

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseCookiePolicy();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute("admin", "{area:exists}/{controller:slugify=Dashboard}/{action:slugify=Index}/{id?}");
        endpoints.MapControllerRoute("default", "{controller:slugify=Home}/{action:slugify=Index}/{id?}");
        endpoints.MapRazorPages();
    });

    app.Run();

    #endregion
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}





