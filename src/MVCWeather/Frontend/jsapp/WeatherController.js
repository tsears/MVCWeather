export default class WeatherController {
    constructor($http, $timeout, $cookies, iconMappings) {
        this.http = $http;
        this.timeout = $timeout;
        this.cookies = $cookies;
        this.query = '';
        this.visibility = 'hidden';
        this.loading = 'false';
        this.iconMappings = iconMappings;

        const lastQuery = this.cookies.get('lastQuery');
        if (lastQuery) {
            this.loading = true;
            this.query = lastQuery;
            this.getWeatherData();
            this.visibility = 'visible';
        }
    }

    getWeatherData() {
        const self = this;
        const url = `/api/Weather?query=${this.query}`;
        this.loading = true;
        
        self.http.get(url).then((resp) => {
            this.cookies.put('lastQuery', this.query);
            self.dailyForecastData = resp.data.daily;
            self.hourlyForecastData = resp.data.hourly;
            self.currentConditions = resp.data.currently;
            self.alerts = resp.data.alerts;

            this.timeout(() => {
                if (this.visibility === 'hidden') {
                    this.visibility = 'visible';
                }
                this.loading = false;
            }, 1000); 
        });
    }
}