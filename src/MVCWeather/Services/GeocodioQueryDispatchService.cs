using System.Net;
using System.Runtime.Serialization.Json;
using tsears.MVCWeather.DataStructures;
using System.Threading.Tasks;

namespace tsears.MVCWeather.Services.Geo {

    public class GeocodioQueryDispatchService : IGeoQueryDispatchService
    {
        private readonly RestRequestor<GeoResponse> _restService;

        public GeocodioQueryDispatchService(RestRequestor<GeoResponse> restService) {
            _restService = restService;
        }

        public async Task<GeoCoordinate> Query(string q) {
            GeoResponse resp = await _restService.MakeRequest(q).ConfigureAwait(false);

            var loc = resp.Results[0].Location;
            return new GeoCoordinate(loc.Lat.ToString(), loc.Long.ToString());
        }
    }
}