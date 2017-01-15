using System;
using System.Text.RegularExpressions;

namespace tsears.MVCWeather.Services.Geo
{
    public enum QueryType {
      Zip,
      CityState,
      StreetCityState,
      StreetCityStateCountry,
      Unknown
    }
    public class GeoQueryParser : IGeoQueryParser
    {
        public QueryType Parse(string q)
        {
          if (Regex.IsMatch(q.Trim(), "^\\d{5}$") || Regex.IsMatch(q.Trim(), "^\\d{5}-\\d{4}$"))
          {
            return QueryType.Zip;
          }
          else if (Regex.IsMatch(q.Trim(), "^.+,\\s?[A-Za-z]{2}"))
          {
            return QueryType.CityState;
          }
          else
          {
            return QueryType.Unknown;
          }
        }
    }
}
