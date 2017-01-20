using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace tsears.MVCWeather
{
    public class Program
    {
        public static void Main(string[] args)
        {

            if (Environment.GetEnvironmentVariable("DARKSKY_API_KEY") == null) {
                throw new Exception("Missing weather API key");
            }
            
            if (Environment.GetEnvironmentVariable("GEOCODIO_API_KEY") == null) {
                throw new Exception("Missing geo API key");
            }
    
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://0.0.0.0:5000")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
