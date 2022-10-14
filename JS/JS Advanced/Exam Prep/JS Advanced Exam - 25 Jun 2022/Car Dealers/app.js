window.addEventListener("load", solve);

function solve() {
    let PublishButton = document.getElementById('publish');
    let make = document.getElementById('make');
    let model = document.getElementById('model');
    let year = document.getElementById('year');
    let fuel = document.getElementById('fuel');
    let originalPrice = document.getElementById('original-cost');
    let sellingPrice = document.getElementById('selling-price');
    let TableBody = document.getElementById('table-body');
    PublishButton.addEventListener('click', (ev) => {
        ev.preventDefault();
        if (make.value !== '' && model.value !== '' && year.value !== '' && fuel.value !== '' && Number(originalPrice.value) <= Number(sellingPrice.value)) {
            let tr = document.createElement('tr');
            let td = document.createElement('td');
            let SellButton = document.createElement('button');
            let EditButton = document.createElement('button');

            tr.setAttribute("class", "row");
            tr.innerHTML = `<td>${make.value}</td><td>${model.value}</td><td>${year.value}</td><td>${fuel.value}</td><td>${originalPrice.value}</td><td>${sellingPrice.value}</td>`;

            SellButton.setAttribute("class", "action-btn sell");
            SellButton.textContent = 'Sell';

            EditButton.setAttribute("class", "action-btn edit");
            EditButton.textContent = 'Edit';

            TableBody.appendChild(tr);
            tr.appendChild(td);
            td.appendChild(EditButton);
            td.appendChild(SellButton);

            make.value = "";
            model.value = "";
            year.value = "";
            fuel.value = "";
            originalPrice.value = "";
            sellingPrice.value = "";

            EditButton.addEventListener("click", function () {
                make.value = parent.make;
                    model.value =
                        year.value =
                            fuel.value =
                                originalPrice.value =
                                    sellingPrice.value =

            })

        }
    });


}
