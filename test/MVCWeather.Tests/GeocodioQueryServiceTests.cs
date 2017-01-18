using Xunit;
using Moq;
using System.Collections.Generic;

namespace tsears.MVCWeather.Services.Geo.Tests
{
    public class GeocodioQueryServiceTests
    {
        private IGeoQueryService _geocodioQueryService;

        public GeocodioQueryServiceTests() {
            var mockParser = new Mock<IGeoQueryParser>();
            mockParser.Setup(p => p.Parse(It.IsAny<string>())).Returns(new Dictionary<string, string>() { {"postal_code", "12345"} });
            
            var mockQueryDispatchSvc = new Mock<IGeoQueryDispatchService>();
            mockQueryDispatchSvc.Setup(q => q.Query(It.IsAny<string>())).ReturnsAsync(new GeoResponse());

            _geocodioQueryService = new GeocodioQueryService(mockParser.Object, mockQueryDispatchSvc.Object);
        }

        [Fact]
        public async void ReturnsGeoInfo() 
        {
            var result = await _geocodioQueryService.Query("foo");

            Assert.True(result is GeoResponse);
        }
    }
}
