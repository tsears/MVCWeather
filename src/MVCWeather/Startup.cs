using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using tsears.MVCWeather.Services.Geo;
using tsears.MVCWeather.Services.Weather;
using tsears.MVCWeather.Services;

namespace tsears.MVCWeather
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var geoRestSvc = new RestRequestor<GeoResponse>();
            var weatherRestSvc = new RestRequestor<ForecastResponse>();
            var parser = new GeoQueryParser();
            var geoDispatchSvc = new GeocodioQueryDispatchService(geoRestSvc);
            var weatherDispatchSvc = new DarkskyQueryDispatchService(weatherRestSvc);
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<IGeoQueryService>(new GeocodioQueryService(parser, geoDispatchSvc));
            services.AddSingleton<IWeatherQueryService>(new DarkskyQueryService(weatherDispatchSvc));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
