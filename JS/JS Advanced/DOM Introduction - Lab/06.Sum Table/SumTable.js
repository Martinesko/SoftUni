function sumTable() {
let list = document.querySelectorAll('table tr');
let total = 0;
    for (let i = 1; i < list.length; i++) {
        let cols = list[i].children;
        let cost = cols[cols.length-1].textContent;
        total += Number(cost);
    }
    document.getElementById("sum").textContent = total;
}