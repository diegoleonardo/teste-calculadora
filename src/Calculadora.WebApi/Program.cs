using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Calculadora.WebApi {
    public class Program {
        public static void Main (string[] args) {
            var configurations = new ConfigurationBuilder ()
                .AddCommandLine (args)
                .Build ();

            var host = new WebHostBuilder ()
                .UseConfiguration (configurations)
                .UseKestrel ()
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .UseIISIntegration ()
                .UseStartup<Startup> ()
                .Build ();

            host.Run ();
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ();
    }
}