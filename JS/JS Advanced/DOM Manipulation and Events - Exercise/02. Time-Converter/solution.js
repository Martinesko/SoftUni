function attachEventsListeners() {
 let daysButton = document.getElementById('daysBtn');
 let hoursButton = document.getElementById('hoursBtn');
 let minutesButton = document.getElementById('minutesBtn');
 let secondsButton = document.getElementById('secondsBtn');
 let daysTextbox = document.getElementById('days');
 let hoursTextbox = document.getElementById('hours');
 let minutesTextbox = document.getElementById('minutes');
 let secondsTextbox = document.getElementById('seconds');
 daysButton.addEventListener('click' , function () {
     let days = daysTextbox.value;
     hoursTextbox.value = days * 24;
     minutesTextbox.value = hoursTextbox.value * 60;
     secondsTextbox.value = minutesTextbox.value * 60;
 })
    hoursButton.addEventListener('click' , function () {
     daysTextbox.value = hoursTextbox.value / 24;
     minutesTextbox.value = hoursTextbox.value * 60;
     secondsTextbox.value = minutesTextbox.value * 60;
 })
    minutesButton.addEventListener('click' , function () {
        hoursTextbox.value = minutesTextbox.value / 60;
     daysTextbox.value = hoursTextbox.value / 24;
     minutesTextbox.value = hoursTextbox.value * 60;
     secondsTextbox.value = minutesTextbox.value * 60;
 })
    secondsButton.addEventListener('click' , function () {
        minutesTextbox.value = secondsTextbox.value / 60;
        hoursTextbox.value = minutesTextbox.value / 60;
     daysTextbox.value = hoursTextbox.value / 24;

 })


}