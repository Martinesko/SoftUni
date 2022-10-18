window.addEventListener('load', solve);

function solve() {
    let model = document.getElementById('model');
    let year = document.getElementById('year');
    let desciption = document.getElementById('description');
    let price = document.getElementById('price');
    let addButton = document.getElementById('add');
    let total = 0;

    addButton.addEventListener('click',(ev)=>{
        ev.preventDefault();
        let _model = model.value;
        let _year = year.value;
        let _description = desciption.value;
        let _price = price.value;
        if(_model === ''|| _year < 0|| _description === ''|| _price < 0){
            return;
        }

        let furnitureList = document.getElementById('furniture-list');
       
        let tr = document.createElement('tr');
        let hiddenTr = document.createElement('tr');
        
        let td = document.createElement('td');
        
        let moreButton = document.createElement('button');
        let buyButton = document.createElement('button');

        tr.setAttribute('class','info');
        hiddenTr.setAttribute('class','hide');
        moreButton.setAttribute('class','moreBtn');
        buyButton.setAttribute('class','buyBtn');
        moreButton.textContent = 'More Info';
        buyButton.textContent = 'Buy it';

        hiddenTr.innerHTML = `<td>Year: ${_year}</td><td colspan="3">Description: ${_description}</td>`;
        tr.innerHTML = `<td>${_model}</td><td>${Number(_price).toFixed(2)}</td>`;
        td.appendChild(moreButton);
        td.appendChild(buyButton);
        tr.appendChild(td);
        furnitureList.appendChild(tr);
        furnitureList.appendChild(hiddenTr);

        model.value = '';
        year.value = '';
        desciption.value = '';
        price.value = '';

        moreButton.addEventListener('click',function () {
            if(moreButton.textContent === 'More Info') {
                hiddenTr.style.display = 'contents';
                moreButton.textContent = 'Less Info';
            }
            else{
                hiddenTr.style.display = 'none';
                moreButton.textContent = 'More Info';
            }

        })
        buyButton.addEventListener('click',function (){
            buyButton.parentElement.parentElement.remove();
            total += Number(_price);
            let totalPrice = document.getElementsByClassName('total-price')[0];
            totalPrice.textContent = total.toFixed(2);
        })
    })
}


