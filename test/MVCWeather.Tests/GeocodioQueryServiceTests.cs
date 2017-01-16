using System;
using Xunit;
using Moq;
using tsears.MVCWeather.Services.Geo;
using System.Collections.Generic;
using tsears.MVCWeather.DataStructures;


namespace tsears.MVCWeather.Services.Geo.Tests
{
    public class GeocodioQueryServiceTests
    {
        private IGeoQueryService _geocodioQueryService;

        public GeocodioQueryServiceTests() {
            var mockParser = new Mock<IGeoQueryParser>();
            mockParser.Setup(p => p.Parse(It.IsAny<string>())).Returns(new Dictionary<string, string>() { {"postal_code", "12345"} });
            
            var mockQueryDispatchSvc = new Mock<IGeoQueryDispatchService>();
            mockQueryDispatchSvc.Setup(q => q.Query(It.IsAny<string>())).ReturnsAsync(new GeoCoordinate("0", "0"));

            _geocodioQueryService = new GeocodioQueryService(mockParser.Object, mockQueryDispatchSvc.Object);
        }

        [Fact]
        public async void ReturnsLatLong() 
        {
            var result = await _geocodioQueryService.Query("foo");

            Assert.Equal("0", result.Lat);
            Assert.Equal("0", result.Long);
        }
    }
}
