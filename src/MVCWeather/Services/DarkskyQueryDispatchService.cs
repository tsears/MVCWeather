using System.Net;
using System.Runtime.Serialization.Json;
using tsears.MVCWeather.DataStructures;
using System.Threading.Tasks;

namespace tsears.MVCWeather.Services.Weather {

    public class DarkskyQueryDispatchService : IWeatherQueryDispatchService
    {
        private readonly RestRequestor<ForecastResponse> _restService;

        public DarkskyQueryDispatchService(RestRequestor<ForecastResponse> restService) {
            _restService = restService;
        }

        public async Task<IForecastResponse> Query(string q) {
            ForecastResponse resp = await _restService.MakeRequest(q).ConfigureAwait(false);
            return resp;
        }
    }
}