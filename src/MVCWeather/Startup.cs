using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using tsears.MVCWeather.Services.Geo;
using tsears.MVCWeather.Services.Weather;
using tsears.MVCWeather.Services;
using Enyim.Caching;

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

            // Add custom services
            services.AddEnyimMemcached(options => Configuration.GetSection("enyimMemcached").Bind(options)); // this was a dumb way to do it...
            var sp = services.BuildServiceProvider();
            var memcachedService = sp.GetService<IMemcachedClient>();
            services.AddSingleton<IGeoQueryService>(new GeocodioQueryService(parser, geoDispatchSvc, memcachedService));
            services.AddSingleton<IWeatherQueryService>(new DarkskyQueryService(weatherDispatchSvc, memcachedService));
  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseStaticFiles();
            app.UseEnyimMemcached();
        }
    }
}
