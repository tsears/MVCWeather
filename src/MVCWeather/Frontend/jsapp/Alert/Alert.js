export default class Alert {
    constructor() {
        this.restrict = 'E';
        this.scope = {
            data: '=',
        };
        this.replace = true;
        this.templateUrl = '/ng-partials/jsapp/Alert/alert.html';
        this.controller = [AlertController];
        this.controllerAs = 'avm';
        this.bindToController = true;
    }
}

class AlertController {
    constructor() {
        this.descriptionVisible = false;
    }

    alertClicked() {
        this.descriptionVisible = !this.descriptionVisible;
    }
}