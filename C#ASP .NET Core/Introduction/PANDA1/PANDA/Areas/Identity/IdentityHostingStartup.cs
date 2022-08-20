using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PANDA.Areas.Identity.IdentityHostingStartup))]
namespace PANDA.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}