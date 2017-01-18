export default class WeatherController {
    constructor($http, $timeout, $cookies, iconMappings) {
        this.http = $http;
        this.timeout = $timeout;
        this.cookies = $cookies;
        this.query = '';
        this.visibility = 'hidden';
        this.loading = false;
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
        const url = `/api/weather?query=${this.query}`;
        this.loading = true;
        
        self.http.get(url).then((resp) => {
            this.cookies.put('lastQuery', this.query);

            self.dailyForecastData = resp.data.Weather.daily;
            self.hourlyForecastData = resp.data.Weather.hourly;
            self.currentConditions = resp.data.Weather.currently;
            self.alerts = resp.data.Weather.alerts;

            self.geoInput = resp.data.Geo.input;
            self.geoMatches = resp.data.Geo.results;

            this.timeout(() => {
                if (this.visibility === 'hidden') {
                    this.visibility = 'visible';
                }
                this.loading = false;
            }, 1000); 
        });
    }
}