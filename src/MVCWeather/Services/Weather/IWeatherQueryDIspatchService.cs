using tsears.MVCWeather.DataStructures;
using System.Threading.Tasks;

namespace tsears.MVCWeather.Services.Weather
{
  public interface IWeatherQueryDispatchService
  {
    Task<IForecastResponse> Query(string query);
  }
}
