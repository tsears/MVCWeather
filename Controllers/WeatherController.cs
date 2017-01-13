using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace tsears.MVCWeather.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
