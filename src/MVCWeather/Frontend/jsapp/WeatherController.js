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
        // self.currentConditions = {
        //     "time": 1484677689,
        //     "summary": "Flurries",
        //     "icon": "snow",
        //     "nearestStormDistance": 0,
        //     "nearestStormBearing": 0,
        //     "precipIntensity": 0.0041,
        //     "precipIntensityError": 0.0016,
        //     "precipProbability": 0.38,
        //     "precipType": "snow",
        //     "temperature": 33.56,
        //     "apparentTemperature": 29.77,
        //     "dewPoint": 28.73,
        //     "humidity": 0.82,
        //     "windSpeed": 4.1,
        //     "windBearing": 154,
        //     "visibility": 9.11,
        //     "cloudCover": 0.99,
        //     "pressure": 1011.81,
        //     "ozone": 305.7
        // }       
        
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