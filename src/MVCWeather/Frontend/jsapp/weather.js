import WeatherController from './WeatherController';
import CurrentConditions from './Card-CurrentConditions/CurrentConditions';
import ForecastDay from './Card-ForecastDay/ForecastDay';
import Alert from './Alert/Alert';
import DailyForecast from './DailyForecast/DailyForecast';


// configure charts//
Chart.defaults.global.defaultFontColor = '#EEE';
Chart.defaults.scale.gridLines.zeroLineColor = '#cecece';


angular.module(['720kb.tooltips']).config(['tooltipsConfProvider', function configConf(tooltipsConfProvider) {
  tooltipsConfProvider.configure({
    'size':'small',
    'side': 'bottom',
  });
}]);

const d = angular.module('weatherDirectives', ['ngDialog', '720kb.tooltips', 'chart.js']);
d.directive('currentConditionsCard', () => new CurrentConditions());
d.directive('forecastDayCard', () => new ForecastDay());
d.directive('alert', () => new Alert());
d.directive('dailyForecast', () => new DailyForecast());

d.constant('iconMappings', {
    'rain' : '/icons/rain.svg',
    'clear-day' : '/icons/clear-day.svg',
    'clear-night' : '/icons/clear-night.svg',
    'snow' : '/icons/snow.svg',
    'sleet' : '/icons/sleet.svg',
    'wind' : '/icons/wind.svg',
    'fog' : '/icons/fog.svg',
    'cloudy' : '/icons/cloudy.svg',
    'partly-cloudy-day' : '/icons/partly-cloudy-day.svg',
    'partly-cloudy-night' : '/icons/partly-cloudy-night.svg',
    'default': '/icons/default.svg',
    'loading': '/icons/loading.svg',
    'magnify': '/icons/magnify.svg',
    'up': '/icons/up.svg',
    'down': '/icons/down.svg'
});

d.filter('compassDirection', () => {
    return (input) => {
        input = input | '';

        if (isNaN(parseFloat(input))) {
            throw new Error("Invalid Argument. Must be a number");
        }

        if (input < 0 || input > 365) {
            throw new Error("Invalid Argument. Must be between 0 and 360");
        }

        if (input > 0 && input <= 11.25) {
            return 'N';
        } else if (input > 11.25 && input <= 33.75) {
            return 'NNE';
        } else if (input > 33.75 && input <= 56.25) {
            return 'NE';
        } else if (input > 56.25 && input <= 78.75) {
            return 'ENE';
        } else if (input > 78.75 && input <= 101.25) {
            return 'E';
        } else if (input > 101.25 && input <= 123.75) {
            return 'ESE';
        } else if (input > 123.75 && input <= 146.25) {
            return 'SE';
        } else if (input > 146.25 && input <= 168.75) {
            return 'SSE';
        } else if (input > 168.75 && input <= 191.25) {
            return 'S';
        } else if (input > 191.25 && input <= 213.75) {
            return 'SSW';
        } else if (input > 213.75 && input <= 236.25) {
            return 'SW';
        } else if (input > 236.25 && input <= 258.75) {
            return 'WSW';
        } else if (input > 258.75 && input <= 281.25) {
            return 'W';
        } else if (input > 281.25 && input <= 303.75) {
            return 'WNW';
        } else if (input > 303.75 && input <= 326.25) {
            return 'NW';
        } else if (input > 326.25 && input <= 348.75) {
            return 'NNW';
        } else if (input > 348.75 && input <= 360) {
            return 'N';
        } else {
            return '-';
        }

    };
});

const app = angular.module('weatherApp', ['weatherDirectives', 'ngAnimate', 'ngCookies']);

app.controller('weatherController', ['$http', '$timeout', '$cookies', 'iconMappings', WeatherController]);
