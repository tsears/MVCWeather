using tsears.MVCWeather.DataStructures;

namespace tsears.MVCWeather.Services.Geo
{
  public interface IGeoQueryDispatchService{
    GeoCoordinate Query(string query);
  }
}
