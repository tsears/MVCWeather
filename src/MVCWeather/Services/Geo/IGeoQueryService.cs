using tsears.MVCWeather.DataStructures;
using System.Threading.Tasks;

namespace tsears.MVCWeather.Services.Geo
{
  public interface IGeoQueryService
  {
    Task<GeoCoordinate> Query(string query);
  }
}
