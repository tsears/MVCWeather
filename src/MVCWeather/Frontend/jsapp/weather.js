import WeatherController from './WeatherController';
import CurrentConditions from './Card-CurrentConditions/CurrentConditions';


const d = angular.module('weatherDirectives', []);
d.directive('currentConditionsCard', () => new CurrentConditions());

const app = angular.module('weatherApp', ['weatherDirectives', 'ngAnimate']);

app.controller('weatherController', ['$http', '$timeout', WeatherController]);