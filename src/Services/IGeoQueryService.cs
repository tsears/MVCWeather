using tsears.MVCWeather.DataStructures;

namespace tsears.MVCWeather.Services.Geo
{
  public interface IGeoQueryService
  {
    GeoCoordinate Query(string query);
  }
}