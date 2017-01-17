describe('Weather Controller Tests', () => {
    let weatherController = null;
    let $httpBackend  = null;
    let createController = null;
    let $rootScope = null;

    beforeEach(angular.mock.module('weatherApp'));

    beforeEach(inject(($injector) => {
        $httpBackend = $injector.get('$httpBackend');
        $rootScope = $injector.get('$rootScope');

        $httpBackend.when('GET', function(url) {
            return url.indexOf('/api/Weather?query=12345') > -1;
        }).respond(200, {
            currently: {
                temperature: 72.0
            },
            daily: {
                summary: "foo",
                icon: "apple",
                data: [
                    { },
                    { }
                ],
            },
            hourly: {
                summary: "bar",
                icon: "banana",
                data: [{},{},{}]
            },
            alerts: [
                {
                    title: "baz"
                },
                {
                    title: "bonk"
                }
            ]
        });

        let $controller = $injector.get('$controller');

        createController = () => {
            return $controller('weatherController', {
                '$scope': $rootScope
            });
        };
    }));

    afterEach(() => {
		$httpBackend.verifyNoOutstandingExpectation();
		$httpBackend.verifyNoOutstandingRequest();
	});

    describe('Query Tests',  () => {
        beforeEach(() => {
            weatherController = createController();
        });

        it('Starts with empty query', () => {
            expect(weatherController.query).toBe('');
        });

        it('Calls weather api', () => {
            const data = 
            $httpBackend.expectGET('/api/Weather?query=12345');
            weatherController.query = '12345';
            weatherController.getWeatherData();

            $httpBackend.flush();
        });

        it('Populates Current Conditions', () => {
            $httpBackend.expectGET('/api/Weather?query=12345');
            weatherController.query = '12345';
            weatherController.getWeatherData();

            $httpBackend.flush();

            expect(weatherController.currentConditions.temperature).toBe(72.0);
        });

        it('Populates Daily Forecasts', () => {
            $httpBackend.expectGET('/api/Weather?query=12345');
            weatherController.query = '12345';
            weatherController.getWeatherData();

            $httpBackend.flush();

            expect(weatherController.dailyForecastData.data.length).toBe(2);
            expect(weatherController.dailyForecastData.summary).toBe('foo');
            expect(weatherController.dailyForecastData.icon).toBe('apple');

        });

        it('Populates Hourly Forecasts', () => {
            $httpBackend.expectGET('/api/Weather?query=12345');
            weatherController.query = '12345';
            weatherController.getWeatherData();

            $httpBackend.flush();

            expect(weatherController.hourlyForecastData.data.length).toBe(3);
            expect(weatherController.hourlyForecastData.summary).toBe("bar");
            expect(weatherController.hourlyForecastData.icon).toBe("banana");
        });

        it('Populates Alerts', () => {
            $httpBackend.expectGET('/api/Weather?query=12345');
            weatherController.query = '12345';
            weatherController.getWeatherData();

            $httpBackend.flush();

            expect(weatherController.alerts.length).toBe(2);
            expect(weatherController.alerts[0].title).toBe('baz');
        });

    });
});