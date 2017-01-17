using tsears.MVCWeather.DataStructures;
using tsears.MVCWeather.Services.Weather;
using System.Threading.Tasks;

namespace tsears.MVCWeather.Services.Weather
{
  public interface IWeatherQueryService
  {
    Task<IForecastResponse> Query(GeoCoordinate coord);
  }
}
