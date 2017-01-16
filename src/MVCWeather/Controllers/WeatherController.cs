using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tsears.MVCWeather.Services.Geo;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace tsears.MVCWeather.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IGeoQueryService _geoQueryService;

        public WeatherController(IGeoQueryService geoQueryService) {
          this._geoQueryService = geoQueryService;
        }
        // GET api/values
        [HttpGet]
        public async Task<string> Get(string query)
        {
            var coords = await _geoQueryService.Query(query);
            return JsonConvert.SerializeObject(coords);
        }
    }
}
