using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ShoppingCartApp.Areas.Identity.IdentityHostingStartup))]
namespace ShoppingCartApp.Areas.Identity
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