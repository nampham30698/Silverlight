using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Silverlight.Web.Areas.Identity.IdentityHostingStartup))]
namespace Silverlight.Web.Areas.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
        });
    }
}
