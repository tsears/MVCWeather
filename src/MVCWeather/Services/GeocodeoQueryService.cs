using tsears.MVCWeather.Services.Geo;
using System.Text;
using tsears.MVCWeather.DataStructures;

namespace tsears.MVCWeather.Services.Geo
{
    public class GeocodioQueryService: IGeoQueryService
    {
        private readonly IGeoQueryParser _geoQueryParser;
        private readonly IGeoQueryDispatchService _geoQueryDispatchService;

        public GeocodioQueryService(IGeoQueryParser geoQueryParser, IGeoQueryDispatchService geoQueryDispatchService) {
            _geoQueryParser = geoQueryParser;
            _geoQueryDispatchService = geoQueryDispatchService;
        }

        public GeoCoordinate Query(string q) {
            var queryParts = _geoQueryParser.Parse(q);
            var sb = new StringBuilder("http://https://api.geocod.io/v1/geocode?");
            
            foreach(var k in queryParts.Keys) {
                sb.Append($"{k}={queryParts[k]}&");
            }

            var query = sb.ToString();

            return _geoQueryDispatchService.Query(query);
        }
    }
}