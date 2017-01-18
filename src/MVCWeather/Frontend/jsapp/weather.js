import WeatherController from './WeatherController';
import CurrentConditions from './Card-CurrentConditions/CurrentConditions';
import ForecastDay from './Card-ForecastDay/ForecastDay';
import Alert from './Alert/Alert';


const d = angular.module('weatherDirectives', []);
d.directive('currentConditionsCard', () => new CurrentConditions());
d.directive('forecastDayCard', () => new ForecastDay());
d.directive('alert', () => new Alert());

d.constant('iconMappings', {
    'rain' : '/icons/rain.svg', //
    'clear-day' : '/icons/clear-day.svg', //
    'clear-night' : '/icons/clear-night.svg', //
    'snow' : '/icons/snow.svg', //
    'sleet' : '/icons/sleet.svg', //
    'wind' : '/icons/wind.svg', //
    'fog' : '/icons/fog.svg', //
    'cloudy' : '/icons/cloudy.svg', //
    'partly-cloudy-day' : '/icons/partly-cloudy-day.svg', //
    'partly-cloudy-night' : '/icons/partly-cloudy-night.svg', //
    'default': '/icons/default.svg'
});

const app = angular.module('weatherApp', ['weatherDirectives', 'ngAnimate']);

app.controller('weatherController', ['$http', '$timeout', WeatherController]);