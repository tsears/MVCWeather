import WeatherController from './WeatherController';
import CurrentConditions from './Card-CurrentConditions/CurrentConditions';
import ForecastDay from './Card-ForecastDay/ForecastDay';
import Alert from './Alert/Alert';


const d = angular.module('weatherDirectives', []);
d.directive('currentConditionsCard', () => new CurrentConditions());
d.directive('forecastDayCard', () => new ForecastDay());
d.directive('alert', () => new Alert());

const app = angular.module('weatherApp', ['weatherDirectives', 'ngAnimate']);

app.controller('weatherController', ['$http', '$timeout', WeatherController]);