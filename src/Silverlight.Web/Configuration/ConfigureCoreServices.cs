using Silverlight.ApplicationCore.Interfaces;
using Silverlight.ApplicationCore.Services;
using Silverlight.Infrastructure.Data;
using Silverlight.Infrastructure.Logging;
using Silverlight.Infrastructure.Services;

namespace Silverlight.Web.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(ITokenClaimsService), typeof(IdentityTokenClaimService));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            return services;
        }
    }
}
