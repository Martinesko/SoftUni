window.addEventListener('load', solve);

function solve() {
    let typeProduct = document.getElementById('type-product');
   let description = document.getElementById('description');
   let clientName = document.getElementById('client-name');
   let clientPhone = document.getElementById('client-phone');
   let submitButton = document.getElementsByTagName('button')[0];
   let clearButton = document.getElementsByClassName('clear-btn')[0];
   let wrapper = document.getElementById('wrapper');
    submitButton.addEventListener('click',
        (e) => {
            e.preventDefault();
            let _typeProduct = typeProduct.value;
            let _description = description.value;
            let _clientName = clientName.value;
            let _clientPhone = clientPhone.value;
            if (_description === '' || _clientName === '' || _clientPhone === '') {
                return;
            }

            let receivedOrdersList = document.getElementById('received-orders');
            let completedOrdersList = document.getElementById('completed-orders');
            let div = document.createElement('div');
            let completeDiv = document.createElement('div');
            completeDiv.setAttribute('class', 'container');
            div.setAttribute('class', 'container');
            let startButton = document.createElement('button');
            let finishButton = document.createElement('button');
            startButton.setAttribute('class', 'start-btn');
            startButton.textContent = 'Start repair';
            finishButton.setAttribute('class', 'finish-btn',);
            finishButton.textContent = 'Finish repair';
            finishButton.disabled = true;

            div.innerHTML = `<h2>Product type for repair: ${_typeProduct}</h2><h3>Client information: ${_clientName}, ${_clientPhone}</h3><h4>Description of the problem: ${_description}</h4>`;

            div.appendChild(startButton);
            div.appendChild(finishButton);
            receivedOrdersList.appendChild(div);

            clientName.value = '';
            clientPhone.value = '';
            description.value = '';

            startButton.addEventListener('click', function () {
                finishButton.disabled = false;
                startButton.disabled = true;
            })

            finishButton.addEventListener('click', function () {
                completeDiv.innerHTML = `<h2>Product type for repair: ${_typeProduct}</h2><h3>Client information: ${_clientName}, ${_clientPhone}</h3><h4>Description of the problem: ${_description}</h4>`;
                completedOrdersList.appendChild(completeDiv);
                finishButton.parentElement.remove();
            })


        })
    clearButton.addEventListener('click', function () {
        const divElements = Array.from(document.querySelectorAll('#completed-orders .container'));
        for (let el of divElements) {
            el.remove();
        }
    })
}