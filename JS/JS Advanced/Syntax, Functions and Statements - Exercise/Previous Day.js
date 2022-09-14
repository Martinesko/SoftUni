function previousDay(year, month, day) {
     let date = new Date(year, month, day);
     date.setDate(date.getDate() - 1);
     console.log(`${date.getFullYear()}-${date.getMonth()}-${date.getDay()}`)
}
previousDay(2016, 9, 30)