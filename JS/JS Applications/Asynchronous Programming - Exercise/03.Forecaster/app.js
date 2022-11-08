function attachEvents() {
let submit = document.getElementById('submit');
let location = document.getElementById('location');
submit.addEventListener("click", async ()=>{
    try {
        let locationsUrl = `http://localhost:3030/jsonstore/forecaster/locations`;
        let locationsResponse = await fetch(locationsUrl);
        let locationsData = await locationsResponse.json();
        if (locationsData.find(x => x.name === location.value) !== undefined) {
            document.getElementById('forecast').style.display = 'block';
        } else {
            document.getElementById('forecast').style.display = 'block';
            document.getElementById('forecast').textContent = "Error"
        }
        let locationCode = locationsData.find(x => x.name === location.value).code;


        let currentUrl = `http://localhost:3030/jsonstore/forecaster/today/${locationCode}`;
        let currentResponse = await fetch(currentUrl);
        let currentData = await currentResponse.json();

        let currentSymbolSpan = document.createElement('span');
        let currentConditionSpan = document.createElement('span');
        let forecasts = document.createElement('div');
        let current = document.getElementById('current');

        currentSymbolSpan.setAttribute('class', 'condition symbol');
        currentConditionSpan.setAttribute('class', 'condition');
        forecasts.setAttribute('class', 'forecasts');
        let symbol = '';
        switch (currentData.forecast.condition) {
            case "Sunny":
                symbol = "☀";
                break;

            case "Partly sunny":
                symbol = '⛅';
                break;

            case "Overcast":
                symbol = "☁";
                break;

            case "Rain":
                symbol = "☂";
                break;
        }


        currentSymbolSpan.textContent = symbol;
        currentConditionSpan.innerHTML = `<span class="forecast-data">${currentData.name}</span><span class="forecast-data">${currentData.forecast.low}°/${currentData.forecast.high}°</span><span class="forecast-data">${currentData.forecast.condition}</span>`;

        forecasts.appendChild(currentSymbolSpan);
        forecasts.appendChild(currentConditionSpan);
        current.appendChild(forecasts);
        document.getElementById('forecast').style.display = 'block';

        let upcomingUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`;
        let upcomingResponse = await fetch(upcomingUrl);
        let upcomingData = await upcomingResponse.json();

        let forecastInfo = document.createElement('div');
        forecastInfo.setAttribute('class', 'forecast-info');

        for (const dayData of upcomingData.forecast) {

            let upcomingSpan = document.createElement('span');

            upcomingSpan.setAttribute('class', 'upcoming');

            let symbol = '';
            switch (dayData.condition) {
                case "Sunny":
                    symbol = "☀";
                    break;

                case "Partly sunny":
                    symbol = '⛅';
                    break;

                case "Overcast":
                    symbol = "☁";
                    break;

                case "Rain":
                    symbol = "☂";
                    break;
            }

            upcomingSpan.innerHTML = `<span class = "symbol">${symbol}</span><span class="forecast-data">${dayData.low}°/${dayData.high}°</span><span class="forecast-data">${dayData.condition}</span>`;
            forecastInfo.appendChild(upcomingSpan);
        }
        document.getElementById('upcoming').appendChild(forecastInfo);
    }
    catch{

    }
})
}
attachEvents()