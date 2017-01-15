using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tsears.MVCWeather.Services.Geo;

namespace tsears.MVCWeather.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IGeoQueryParser _geoQueryParser;

        public WeatherController(IGeoQueryParser geoQueryParser) {
          this._geoQueryParser = geoQueryParser;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
