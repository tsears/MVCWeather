export default class CurrentConditions {
    constructor() {
        this.restrict = 'E';
        this.scope = {
            data: '=',
        };
        this.replace = true;
        this.templateUrl = '/ng-partials/jsapp/Card-CurrentConditions/currentConditions.html';
        this.controllerAs = "ccvm";
        this.bindToController = true;
        this.controller = ['iconMappings', CurrentConditionsController];
    }
}

class CurrentConditionsController {
    constructor(iconMappings) {
        this.iconMappings = iconMappings;
    }
}