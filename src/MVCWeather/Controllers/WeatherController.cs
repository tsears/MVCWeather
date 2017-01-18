using Microsoft.AspNetCore.Mvc;
using tsears.MVCWeather.Services.Geo;
using tsears.MVCWeather.Services.Weather;
using Newtonsoft.Json;
using System.Threading.Tasks;
using tsears.MVCWeather.DataStructures;

namespace tsears.MVCWeather.Controllers
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private readonly IGeoQueryService _geoQueryService;
        private readonly IWeatherQueryService _weatherQueryService;

        public WeatherController(IGeoQueryService geoQueryService, IWeatherQueryService weatherQueryService) {
          this._geoQueryService = geoQueryService;
          this._weatherQueryService = weatherQueryService;
        }

        // GET api/values
        [HttpGet]
        public async Task<string> Get(string query)
        {
            var geo = await _geoQueryService.Query(query);
            var coords = new GeoCoordinate(geo.Results[0].Location.Lat.ToString(), geo.Results[0].Location.Long.ToString());
            
            var forecast = await _weatherQueryService.Query(coords);

            var resp = new WeatherResponse(geo, forecast);

            return JsonConvert.SerializeObject(resp);
        }

        [HttpGet]
        [Route("reverse")]
        public async Task<string> Get(string lat, string lon) {
            var coords = new GeoCoordinate(lat, lon);

            var geoTask = _geoQueryService.ReverseQuery(coords);
            var forecastTask = _weatherQueryService.Query(coords);

            await Task.WhenAll(new Task[] {geoTask, forecastTask});

            var geo = await geoTask;
            var forecast = await forecastTask;

            var resp = new WeatherResponse(geo, forecast);
            return JsonConvert.SerializeObject(resp);
        }
    }
}
