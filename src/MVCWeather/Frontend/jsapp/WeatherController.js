export default class WeatherController {
    constructor($http, $timeout, $cookies) {
        this.http = $http;
        this.timeout = $timeout;
        this.cookies = $cookies;
        this.query = '';
        this.visibility = 'hidden';

        const lastQuery = this.cookies.get('lastQuery');
        if (lastQuery) {
            this.query = lastQuery;
            this.getWeatherData();
        }
    }

    getWeatherData() {
        const self = this;
        const url = `/api/Weather?query=${this.query}`;
        
        self.http.get(url).then((resp) => {
            this.cookies.put('lastQuery', this.query);
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