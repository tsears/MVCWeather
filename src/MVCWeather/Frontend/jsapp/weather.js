import WeatherController from './WeatherController';
import CurrentConditions from './Card-CurrentConditions/CurrentConditions';
import ForecastDay from './Card-ForecastDay/ForecastDay';
import Alert from './Alert/Alert';
import DailyForecast from './DailyForecast/DailyForecast';


const d = angular.module('weatherDirectives', []);
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

const app = angular.module('weatherApp', ['weatherDirectives', 'ngAnimate', 'ngCookies']);

app.controller('weatherController', ['$http', '$timeout', '$cookies', 'iconMappings', WeatherController]);