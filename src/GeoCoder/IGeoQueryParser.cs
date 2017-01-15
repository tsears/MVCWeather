
namespace tsears.MVCWeather.Services.Geo
{
  public interface IGeoQueryParser {
    QueryType Parse(string query);
  }
}
