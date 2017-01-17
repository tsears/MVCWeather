using System.Collections.Generic;

namespace tsears.MVCWeather.Services.Geo
{
  public interface IGeoQueryParser {
    Dictionary<string, string> Parse(string query);
  }
}
