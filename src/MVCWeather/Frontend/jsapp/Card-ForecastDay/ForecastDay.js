export default class ForecastDay {
    constructor() {
        this.restrict = 'E';
        this.scope = {
            data: '=',
        };
        this.replace = true;
        this.templateUrl = '/ng-partials/jsapp/Card-ForecastDay/forecastDay.html';
        this.controller = ['$document', 'iconMappings', 'ngDialog', ForecastDayController];
        this.controllerAs = 'fvm';
        this.bindToController = true;
    }
}

class ForecastDayController {
    constructor($document, iconMappings, ngDialog) {
        this.iconMappings = iconMappings;
        this.ngDialog =  ngDialog;
        this.document = $document;
    }

    openDialog() {
        const body = this.document[0].body;
        body.classList.add('hideOverflow');
        
        const close = this.ngDialog.open({
            template: '/ng-partials/jsapp/Card-ForecastDay/forecastDayDialog.html',
            className: 'ngdialog-theme-dark',
            controller: () => { return this; },
            controllerAs: 'fvm'
        });

        close.closePromise.then(() => {
            body.classList.remove('hideOverflow');
        });
    }
}