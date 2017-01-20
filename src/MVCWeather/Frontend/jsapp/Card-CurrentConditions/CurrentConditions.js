export default class CurrentConditions {
    constructor() {
        this.restrict = 'E';
        this.scope = {};
        this.replace = true;
        this.templateUrl = '/ng-partials/jsapp/Card-CurrentConditions/currentConditions.html';
        this.controllerAs = "ccvm";
        this.bindToController =  {
            data: '=',
            detail: '=',
            geo: '='
        };
        this.controller = ['iconMappings', 'ngDialog', CurrentConditionsController];
    }
}

class CurrentConditionsController {
    constructor(iconMappings, ngDialog) {
        this.iconMappings = iconMappings;
        this.ngDialog = ngDialog;
    }
}