using Xunit;
using Moq;
using System.Collections.Generic;
using Enyim.Caching;
using Enyim.Caching.Memcached.Results;
using System.Threading.Tasks;

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

            var mockMemcachedClient = new Mock<IMemcachedClient>();
            var mockOpResult = new Mock<IGetOperationResult<GeoResponse>>();
            mockMemcachedClient.Setup(m => m.GetAsync<GeoResponse>(It.IsAny<string>())).Returns(Task.FromResult(mockOpResult.Object));

            _geocodioQueryService = new GeocodioQueryService(mockParser.Object, mockQueryDispatchSvc.Object, mockMemcachedClient.Object);
        }

        [Fact]
        public async void ReturnsGeoInfo()
        {
            var result = await _geocodioQueryService.Query("foo");

            Assert.True(result is GeoResponse);
        }
    }
}
