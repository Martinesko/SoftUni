async function getInfo() {
    let stopInfoElement = document.getElementById('stopId');
    let stopNameElement = document.getElementById('stopName');
    let busList = document.getElementById('buses');
    let stopId = stopInfoElement.value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`

    busList.innerHTML = '';
    stopId.value = '';
try{
    const response = await fetch(url);
    const date = await response.json();

    stopNameElement.textContent = date.name;

    Object.entries(date.buses).forEach(([bus,time])=>{
        let li = document.createElement('li');
        li.textContent = `"Bus ${bus} arrives in ${time} minutes"`;
        busList.appendChild(li);
    })
}
catch (error){
    stopNameElement.textContent = "Error";
}
}