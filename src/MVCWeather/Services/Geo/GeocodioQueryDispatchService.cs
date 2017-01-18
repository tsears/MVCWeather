using System.Threading.Tasks;

namespace tsears.MVCWeather.Services.Geo
{

    public class GeocodioQueryDispatchService : IGeoQueryDispatchService
    {
        private readonly RestRequestor<GeoResponse> _restService;

        public GeocodioQueryDispatchService(RestRequestor<GeoResponse> restService) {
            _restService = restService;
        }

        public async Task<GeoResponse> Query(string q) {
            GeoResponse resp = await _restService.MakeRequest(q).ConfigureAwait(false);
            return resp;
        }
    }
}