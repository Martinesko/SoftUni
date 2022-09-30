function deleteByEmail() {
    let textBoxValue = document.getElementsByName('email')[0].value;
    let customers = document.getElementById('customers').getElementsByTagName('td');
    let flag = false;
    for (let customerEmail of customers) {
        if(customerEmail.textContent === textBoxValue){
            customerEmail.parentElement.remove();
            flag = true;
        }

            let result = document.getElementById('result');
            result.textContent = flag? 'Deleted' : 'Not found.';

    }
}