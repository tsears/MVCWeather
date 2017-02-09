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
            hourly: '=',
            geo: '='
        };
        this.controller = ['iconMappings', 'ngDialog', '$filter', CurrentConditionsController];
    }
}

class CurrentConditionsController {
    constructor(iconMappings, ngDialog, $filter) {
        this.iconMappings = iconMappings;
        this.ngDialog = ngDialog;
        this.filter = $filter;

        this.chartOptions = {
          annotation: {
            annotations: [
              {
                type: 'line',
                mode: 'vertical',
                borderColor: 'white',
                borderWidth: 1,
                scaleID: 'time-scale'
              },
              {
                type: 'line',
                mode: 'horizontal',
                value: '32',
                borderColor: 'blue',
                borderWidth: 1,
                scaleID: 'temp-scale'
              },
            ]
          },
          //showLines: false,
          maintainAspectRatio: false,
          scales: {
            xAxes: [{
              id: 'time-scale',
              ticks: {
                //maxTicksLimit: 10,
                callback: (v, i, values) => {
                  const date = new Date(v * 1000);
                  return this.filter('date')(date.toISOString(), 'EEE h:mm a');
                }
              },
            }],
            yAxes: [{
              id: 'temp-scale',
              ticks: {
                maxTicksLimit: 10,
                callback: (v, i, values) => {
                  return Math.round(v) + '°';
                }
              },
              scaleLabel: {
                labelString: 'Temperature'
              }
            }]
          },
          tooltips: {
            callbacks: {
              label: (item, data) => {
                console.log(item);
                console.log(data);
                return `${data.datasets[item.datasetIndex].label} : ${Math.round(item.yLabel, 0)}°`;
              }
            },
          },
        };
    }

    $onInit() {
      //this.chartData = [this.hourly.data.map(d => { return {x: d.time, y: d.temperature}; })];
      this.chartData = [this.hourly.data.map(d => { return d.temperature; })];
      this.chartLabels = this.hourly.data.map(d => { return d.time; });
      this.chartSeries = ['Temperature'];
      const currentWeatherTime = Math.floor(new Date().getTime() / 1000);
      const currentWeatherTimeLastIndex = this.hourly.data.findIndex((d, i) => {return d.time > currentWeatherTime; });
      this.chartOptions.annotation.annotations[0].value = this.hourly.data[currentWeatherTimeLastIndex - 1].time;
    }
}
