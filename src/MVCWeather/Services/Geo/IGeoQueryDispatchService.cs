using System.Threading.Tasks;

namespace tsears.MVCWeather.Services.Geo
{
    public interface IGeoQueryDispatchService{
    Task<GeoResponse> Query(string query);
  }
}
