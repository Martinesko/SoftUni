function attachEvents() {
    let person = document.getElementById('person');
    let phone = document.getElementById('phone');
    let createBtn = document.getElementById('btnCreate');
    let loadBtn = document.getElementById('btnLoad');
    createBtn.addEventListener('click', async () => {
        let object = {'person': person.value, 'phone': phone.value};
        await fetch('http://localhost:3030/jsonstore/phonebook', {
            method: "post",
            headers: {'Content-type': 'application/json'},
            body: JSON.stringify(object)
        });
    })
    loadBtn.addEventListener('click', async () => {
        let phonebookResponse = await fetch('http://localhost:3030/jsonstore/phonebook');
        let phonebookData = await phonebookResponse.json();
        let phonebook = document.getElementById('phonebook');
        phonebook.innerHTML = '';
        Object.entries(phonebookData).forEach(([id, data]) => {
            let li = document.createElement('li');
            li.innerHTML = `${data.person}: ${data.phone}`
            let button = document.createElement('button');
            button.textContent = 'Delete';
            li.appendChild(button);
            phonebook.appendChild(li);
            button.addEventListener('click', async () => {
                await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`, {method: 'DELETE'})
            })
        })
    })
}
attachEvents();