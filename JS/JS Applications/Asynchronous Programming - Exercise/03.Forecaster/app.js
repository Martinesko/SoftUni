function attachEvents() {
let submit = document.getElementById('submit');
submit.addEventListener("click", getWeather())

}
async function getWeather(){
    const url = `http://localhost:3030/jsonstore/forecaster/locations`;
    let location = document.getElementById('location').value;
    let response = await fetch(url);
    const date = await response.json();
    const info = date.find(x=>x.name === location);

     createWeather(info.code);
     upcomingWeather(info.code);
}
async function createWeather(code){
    const url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
    let location = document.getElementById('location').value;
    let response = await fetch(url);
    let date = await response.json();
    let currentElement = document.getElementById('current');
    let span = document.createElement('span');
    span.innerHTML = `</span><span class = "forecast-data">${location}</span><span>${date.low}°/${date.high}°</span><span>${date.condition}</span>`;
    currentElement.appendChild(span);
}
async function upcomingWeather(code){
    const url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
    let location = document.getElementById('location').value;
    let response = await fetch(url);
    let date = await response.json();
    let upcomingElement = document.getElementById('upcoming');
    Object.entries(date).forEach(([low,high,condition])=>{
        let span = document.createElement('span');
        span.innerHTML = `<span class = "forecast-data">${location}</span><span>${date.low}°/${date.high}°</span><span>${date.condition}</span>`;
        upcomingElement.appendChild(span);
    })
}
attachEvents()