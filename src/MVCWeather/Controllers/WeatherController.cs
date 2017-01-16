using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tsears.MVCWeather.Services.Geo;
using tsears.MVCWeather.Services.Weather;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace tsears.MVCWeather.Controllers
{
    [Route("api/[controller]")]
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
            var coords = await _geoQueryService.Query(query);
            var forecast = await _weatherQueryService.Query(coords);
            return JsonConvert.SerializeObject(forecast);
        }
    }
}
