export default class WeatherController {
    constructor($http, $timeout) {
        this.http = $http;
        this.timeout = $timeout;
        this.query = '';
        this.visibility = 'hidden';
    }

    getWeatherData() {
        const self = this;
        const url = `/api/Weather?query=${this.query}`;
        
        self.http.get(url).then((resp) => {
            self.dailyForecastData = resp.data.daily;
            self.hourlyForecastData = resp.data.hourly;
            self.currentConditions = resp.data.currently;
            self.alerts = resp.data.alerts;

            this.timeout(() => {
                this.visibility = 'visible';
            }, 1000); 
        });
    }
}