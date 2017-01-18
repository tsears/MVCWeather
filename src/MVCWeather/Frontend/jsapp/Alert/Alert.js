export default class Alert {
    constructor() {
        this.restrict = 'E';
        this.scope = {
            data: '=',
        };
        this.replace = true;
        this.templateUrl = '/ng-partials/jsapp/Alert/alert.html';
        this.controller = ['iconMappings', AlertController];
        this.controllerAs = 'avm';
        this.bindToController = true;
    }
}

class AlertController {
    constructor(iconMappings) {
        this.descriptionVisible = false;
        this.iconMappings = iconMappings;
    }

    alertClicked() {
        this.descriptionVisible = !this.descriptionVisible;
    }
}