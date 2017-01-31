using System;
using Xunit;
using Moq;
using tsears.MVCWeather.Services.Weather;
using System.Collections.Generic;
using tsears.MVCWeather.DataStructures;
using Enyim.Caching;
using Enyim.Caching.Memcached.Results;
using System.Threading.Tasks;


namespace tsears.MVCWeather.Services.Weather.Tests
{
    public class DarkskyQueryServiceTests
    {
        private IWeatherQueryService _darkskyQueryService;

        public DarkskyQueryServiceTests() {
            var mockQueryDispatchSvc = new Mock<IWeatherQueryDispatchService>();
            mockQueryDispatchSvc.Setup(q => q.Query(It.IsAny<string>())).ReturnsAsync(new ForecastResponse());

            var mockMemcachedClient = new Mock<IMemcachedClient>();
            var mockOpResult = new Mock<IGetOperationResult<ForecastResponse>>();
            mockMemcachedClient.Setup(m => m.GetAsync<ForecastResponse>(It.IsAny<string>())).Returns(Task.FromResult(mockOpResult.Object));

            _darkskyQueryService = new DarkskyQueryService(mockQueryDispatchSvc.Object, mockMemcachedClient.Object);
        }

        [Fact]
        public async void ReturnsForecast()
        {
            var result = await _darkskyQueryService.Query(new GeoCoordinate("0", "0"));

            Assert.True(result is ForecastResponse);
        }
    }
}
