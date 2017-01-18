using System.Threading.Tasks;
using tsears.MVCWeather.DataStructures;

namespace tsears.MVCWeather.Services.Geo
{
    public interface IGeoQueryService
  {
    Task<GeoResponse> Query(string query);
    Task<GeoResponse> ReverseQuery(GeoCoordinate geo);
  }
}
