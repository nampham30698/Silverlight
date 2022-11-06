using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.Infrastructure.Data;
using Silverlight.Infrastructure.Identity;

namespace Silverlight.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            // Silverlight DbContext
            services.AddDbContext<SilverlightDbContext>(c =>
                c.UseSqlServer(configuration.GetConnectionString("SilverlightConnection")));

            // Add Identity DbContext
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
        }
    }
}
