using Autofac;
using Autofac.Extensions.DependencyInjection;
using Silverlight.ApplicationCore.Interfaces;

namespace Silverlight.Web.Autofac
{
    public static class AutofacConfig 
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            // Call ConfigureContainer on the Host sub property 
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterAssemblyTypes(typeof(ICategoryService).Assembly)
                .Where(x => x.Namespace == "Silverlight.ApplicationCore.Interfaces" ||
                            x.Namespace == "Silverlight.ApplicationCore.Services")
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

                builder.RegisterAssemblyTypes(typeof(ICategoryService).Assembly)
                    .Where(x => x.Namespace == "Silverlight.ApplicationCore.Interfaces" ||
                                x.Namespace == "Silverlight.ApplicationCore.Services")
                    .AsSelf()
                    .InstancePerLifetimeScope()
                    .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            });
            
        }
    }
}
