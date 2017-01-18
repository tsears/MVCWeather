using tsears.MVCWeather.Services.Geo;
using tsears.MVCWeather.Services.Weather;

namespace tsears.MVCWeather.DataStructures {
    public class WeatherResponse {
        private GeoResponse _geo;
        private IForecastResponse _weather;
        public WeatherResponse(GeoResponse geo, IForecastResponse weather) {
            this._geo = geo;
            this._weather = weather;
        }

        public GeoResponse Geo
        {
            get { return _geo; }
        }

        public IForecastResponse Weather
        {
            get { return _weather; }
        }
    }
}