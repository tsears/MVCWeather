using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace tsears.MVCWeather.Services.Geo
{

    public class GeoQueryParser : IGeoQueryParser
    {
        public Dictionary<string, string> Parse(string q)
        {
          QueryType qType;
          Dictionary<string, string> parts;

          if (Regex.IsMatch(q.Trim(), "^\\d{5}$") || Regex.IsMatch(q.Trim(), "^\\d{5}-\\d{4}$"))
          {
            qType = QueryType.Zip;
          }
          else if (Regex.IsMatch(q.Trim(), "^.+,\\s?[A-Za-z]{2}"))
          {
            qType = QueryType.CityState;
          }
          else
          {
            throw new ArgumentException("Unable to parse query");
          }

          parts = new Dictionary<string, string>();

          switch (qType) {
            case QueryType.Zip:
              parts.Add("postal_code", q.Trim());
              break;
            case QueryType.CityState:
              var cityStateParts = q.Trim().Split(',');
              parts.Add("city", cityStateParts[0].Trim());
              parts.Add("state", cityStateParts[1].Trim());
              break;
            default:
              throw new NotImplementedException();
              break;
          }

          return parts;
        }
    }
}
