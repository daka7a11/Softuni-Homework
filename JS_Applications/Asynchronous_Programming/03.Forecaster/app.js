function attachEvents() {
  const weatherSymbols = {
    Sunny: "☀️",
    "Partly sunny": "⛅️",
    Overcast: "☁️",
    Rain: "☂️",
    Degrees: "°",
  };

  const baseUrl = "http://localhost:3030/jsonstore/forecaster";

  const getWeatherBtn = document.getElementById("submit");

  const forecastCurrEl = document.getElementById("current");
  const forecastUpcomingEl = document.getElementById("upcoming");
  const mainForecastEl = document.getElementById("forecast");
  const locationEl = document.getElementById("location");

  let locationCode = "";

  getWeatherBtn.addEventListener("click", (e) => {
    e.preventDefault();
    fetch(baseUrl + "/locations")
      .then((response) => response.json())
      .then((data) => {
        locationEl.textContent = "";

        const location = data.filter((x) => x.name === locationEl.value)[0];
        mainForecastEl.style.display = "block";

        const labelEl = document.querySelector("#current .label");
        if (location === undefined) {
          const currConditionDiv = document.querySelector(
            "#current .forecasts"
          );
          if (currConditionDiv) {
            currConditionDiv.remove();
          }
          labelEl.textContent = "Error";
          labelEl.style.backgroundColor = "red";
          document.getElementById("upcoming").style.display = "none";
        } else {
          labelEl.textContent = "Current conditions";
          labelEl.style.backgroundColor = "";
          document.getElementById("upcoming").style.display = "";
        }

        locationEl.value = "";

        if (location === undefined) {
          return;
        }
        locationCode = location.code;

        fetch(baseUrl + `/today/${locationCode}`)
          .then((response) => response.json())
          .then((data) => {
            const currObj = data;

            const divToRemove = document.querySelector(".forecasts");
            if (divToRemove != null) {
              divToRemove.remove();
            }

            const forecastsDiv = document.createElement("div");
            forecastsDiv.classList.add("forecasts");

            const symbolSpan = document.createElement("span");
            symbolSpan.classList.add("condition");
            symbolSpan.classList.add("symbol");
            symbolSpan.textContent = weatherSymbols[currObj.forecast.condition];

            const conditionSpan = document.createElement("span");
            conditionSpan.classList.add("condition");

            const spanDataLoc = document.createElement("span");
            spanDataLoc.classList.add("forecast-data");
            spanDataLoc.textContent = currObj.name;

            const spanDataDegree = document.createElement("span");
            spanDataDegree.classList.add("forecast-data");
            spanDataDegree.textContent = `${weatherSymbols["Degrees"]}${currObj.forecast.low}/${weatherSymbols["Degrees"]}${currObj.forecast.high}`;

            const spanDataWeather = document.createElement("span");
            spanDataWeather.classList.add("forecast-data");
            spanDataWeather.textContent = currObj.forecast.condition;

            conditionSpan.appendChild(spanDataLoc);
            conditionSpan.appendChild(spanDataDegree);
            conditionSpan.appendChild(spanDataWeather);

            forecastsDiv.appendChild(symbolSpan);
            forecastsDiv.appendChild(conditionSpan);

            forecastCurrEl.appendChild(forecastsDiv);
          });

        fetch(baseUrl + `/upcoming/${locationCode}`)
          .then((response) => response.json())
          .then((data) => {
            const divToRemove = document.querySelector(".forecast-info");
            if (divToRemove != null) {
              divToRemove.remove();
            }

            const forecastInfoDiv = document.createElement("div");
            forecastInfoDiv.classList.add("forecast-info");

            data.forecast.forEach((currData) => {
              const upcomingSpan = document.createElement("span");
              upcomingSpan.classList.add("upcoming");

              const symbolSpan = document.createElement("span");
              symbolSpan.classList.add("symbol");
              symbolSpan.textContent = weatherSymbols[currData.condition];

              const degreeSpan = document.createElement("span");
              degreeSpan.classList.add("forecast-data");
              degreeSpan.textContent = `${currData.low}${weatherSymbols["Degrees"]}/${currData.high}${weatherSymbols["Degrees"]}`;

              const conditionSpan = document.createElement("span");
              conditionSpan.classList.add("forecast-data");
              conditionSpan.textContent = currData.condition;

              upcomingSpan.appendChild(symbolSpan);
              upcomingSpan.appendChild(degreeSpan);
              upcomingSpan.appendChild(conditionSpan);

              forecastInfoDiv.appendChild(upcomingSpan);
            });

            forecastUpcomingEl.appendChild(forecastInfoDiv);
          });
      });
  });
}

attachEvents();
