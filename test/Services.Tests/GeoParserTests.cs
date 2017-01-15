using System;
using Xunit;
using tsears.MVCWeather.Services.Geo;

namespace tsears.MVCWeather.Services.Geo.Tests
{
    public class GeoQueryParser_Should
    {
        private readonly GeoQueryParser _geoQueryParser;

        public GeoQueryParser_Should() {
          _geoQueryParser = new GeoQueryParser();
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("12345-1234")]
        public void IdentifyZipCode(string val)
        {
            var result = _geoQueryParser.Parse(val);

            Assert.True(result.ContainsKey("postal_code"));
        }

        [Theory]
        [InlineData("Abc Def, CD")]
        [InlineData("Abc, BC")]
        public void IdentifyCityState(string val)
        {
            var result = _geoQueryParser.Parse(val);

            Assert.True(result.ContainsKey("city"));
            Assert.True(result.ContainsKey("state"));
        }

        [Fact]
        public void ReturnCorrectZipCode() {
          var result = _geoQueryParser.Parse("12345");

          Assert.Equal("12345", result["postal_code"]);
        }

        [Fact]
        public void ReturnCorrectCityAndState() {
          var result = _geoQueryParser.Parse("City, State");

          Assert.Equal("City", result["city"]);
          Assert.Equal("State", result["state"]);
        }
    }
}
