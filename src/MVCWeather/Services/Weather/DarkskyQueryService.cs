using tsears.MVCWeather.Services.Geo;
using System.Text;
using System;
using System.Threading.Tasks;
using tsears.MVCWeather.DataStructures;
using Enyim.Caching;

namespace tsears.MVCWeather.Services.Weather
{
    public class DarkskyQueryService: IWeatherQueryService
    {
        private readonly IWeatherQueryDispatchService _weatherQueryDispatchService;
        private readonly IMemcachedClient _memcachedClient;

        public DarkskyQueryService(IWeatherQueryDispatchService weatherQueryDispatchService, IMemcachedClient memcachedClient) {
            _weatherQueryDispatchService = weatherQueryDispatchService;
            _memcachedClient = memcachedClient;
        }

        public async Task<IForecastResponse> Query(GeoCoordinate coord) {

            var cacheKey = $"{coord.Lat},{coord.Long}";

            var result = await _memcachedClient.GetAsync<ForecastResponse>(cacheKey);
            if (!result.Success)
            {
                var sb = new StringBuilder("https://api.darksky.net/forecast/");
        
                sb.Append(Environment.GetEnvironmentVariable("DARKSKY_API_KEY"));
                sb.Append($"/{coord.Lat},{coord.Long}");

                var query = sb.ToString();

                var forecast = await _weatherQueryDispatchService.Query(query).ConfigureAwait(false);
                await _memcachedClient.AddAsync(cacheKey, forecast, 600);
                return forecast;
            }
            else
            {
                return result.Value;
            }
        }
    }
}