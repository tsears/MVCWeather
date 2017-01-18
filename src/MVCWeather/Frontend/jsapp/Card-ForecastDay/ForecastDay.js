export default class ForecastDay {
    constructor() {
        this.restrict = 'E';
        this.scope = {
            data: '=',
        };
        this.replace = true;
        this.templateUrl = '/ng-partials/jsapp/Card-ForecastDay/forecastDay.html';
        this.controller = ['iconMappings', ForecastDayController];
        this.controllerAs = 'fvm';
        this.bindToController = true;
    }
}

class ForecastDayController {
    constructor(iconMappings) {
        this.iconMappings = iconMappings;
    }
}