using Calculadora.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Calculadora.TestesIntegracao {
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup> {
        protected override void ConfigureWebHost (IWebHostBuilder builder) {
            builder.ConfigureServices (services => {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection ()
                    .AddEntityFrameworkInMemoryDatabase ()
                    .BuildServiceProvider ();
                var sp = services.BuildServiceProvider ();

                using (var scope = sp.CreateScope ()) {
                    var scopedServices = scope.ServiceProvider;
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>> ();
                }
            });
        }
    }
}