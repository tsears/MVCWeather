export default class DailyForecast {
    constructor() {
        this.restrict = 'E';
        this.scope = {};
        this.replace = true;
        this.templateUrl = '/ng-partials/jsapp/DailyForecast/dailyForecast.html';
        this.controller = ['ngDialog', DailyForecastController];
        this.controllerAs = "dfvm";
        this.bindToController = { data: '=' };
    }

    link(scope, elem, attr ) {
        const backButton = document.getElementById('forecast-back');
        const forwardButton = document.getElementById('forecast-forward');
        const itemContainer = document.getElementById('forecast-container');
        const scrollDistance = 350; 

        const smoothScroll = (direction) => {
            let chunk = scrollDistance / 120; // how far we have to travel each frame @ 120fps
            if (chunk < 1) chunk = 1; // nothing happens if you add < 1 to scroll
            const interval = 500 / 120; // length of an interval assuming a 500ms scroll time
            let framesRendered = 0; // so we know when to stop the animation.

            const id = setInterval(() => {
                ++framesRendered;
                
                if (direction === 'forward') {
                    itemContainer.scrollLeft += chunk;
                } else {
                    itemContainer.scrollLeft -= chunk;
                }
                
                if (framesRendered === 120) { 
                    clearInterval(id); 
                    framesRendered = 0; 
                }
            }, interval);
        };

        const handleBackClick = () => {
            smoothScroll('back');
        };

        const handleForwardClick = () => {
            smoothScroll('forward');
            //itemContainer.scrollLeft += 20;
        };

        backButton.addEventListener('click', handleBackClick);
        forwardButton.addEventListener('click', handleForwardClick);
    }
}

class DailyForecastController {
 
}

