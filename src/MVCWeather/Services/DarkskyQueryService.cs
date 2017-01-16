using tsears.MVCWeather.Services.Geo;
using System.Text;
using System;
using System.Threading.Tasks;
using tsears.MVCWeather.DataStructures;

namespace tsears.MVCWeather.Services.Weather
{
    public class DarkskyQueryService: IWeatherQueryService
    {
        private readonly IWeatherQueryDispatchService _weatherQueryDispatchService;

        public DarkskyQueryService(IWeatherQueryDispatchService weatherQueryDispatchService) {
            _weatherQueryDispatchService = weatherQueryDispatchService;
        }

        public async Task<IForecastResponse> Query(GeoCoordinate coord) {
            var sb = new StringBuilder("https://api.darksky.net/forecast/");
        
            sb.Append(Environment.GetEnvironmentVariable("DARKSKY_API_KEY"));
            sb.Append($"/{coord.Lat},{coord.Long}");

            var query = sb.ToString();

            return await _weatherQueryDispatchService.Query(query).ConfigureAwait(false);
        }
    }
}