function solve() {

    let recipientName = document.getElementById('recipientName');
    let title = document.getElementById('title');
    let message = document.getElementById('message');
    let addButton = document.getElementById('add');
    let resetButton = document.getElementById('reset');
    addButton.addEventListener('click',(e)=>{
        e.preventDefault();
        if(recipientName.value ===''||title.value === ''|| message.value === ''){
            return;
        }
        e.preventDefault();//nebrarai 4e nema da baca
        let _recipientName = recipientName.value;
        let _title = title.value;
        let _message = message.value;
        let list = document.getElementById('list');
        let li = document.createElement('li');
        li.innerHTML = `<h4>Title: ${_title}</h4> <h4>Recipient Name: ${_recipientName}</h4> <span>${_message}</span>`;
        let sendButton = document.createElement('button');
        sendButton.setAttribute('type','submit');
        sendButton.setAttribute('id','send');
        sendButton.textContent = 'Send';
        let deleteButton = document.createElement('button');
        deleteButton.setAttribute('type','submit');
        deleteButton.setAttribute('id','delete')
        deleteButton.textContent = 'Delete';
        let div = document.createElement('div');
        div.setAttribute('id','list-action')

        div.appendChild(sendButton);
        div.appendChild(deleteButton);
        li.appendChild(div);
        list.appendChild(li);

        recipientName.value = '';
        title.value = '';
        message.value = '';
        sendButton.addEventListener('click',function () {
           let sentList = document.getElementsByClassName('sent-list')[0];
           let sendli = document.createElement('li');
           let senddiv = document.createElement('div');
           sendli.innerHTML = `<span>To: ${_recipientName}</span><span>Title: ${_title}</span>`;
           senddiv.setAttribute('class','btn');
           let sentDeleteButton = document.createElement('button');
           sentDeleteButton.setAttribute('type','submit');
           sentDeleteButton.setAttribute('class','delete');
           sentDeleteButton.textContent = 'Delete';
           senddiv.appendChild(sentDeleteButton);
           sendli.appendChild(senddiv);
           sentList.appendChild(sendli);
           sendButton.parentElement.parentElement.remove();
            sentDeleteButton.addEventListener('click',function () {
                let deleteList = document.getElementsByClassName('delete-list')[0];
                let deleteli = document.createElement('li');
                deleteli.innerHTML = `<span>To: ${_recipientName}</span><span>Title: ${_title}</span>`
                sentDeleteButton.parentElement.parentElement.remove();
                deleteList.appendChild(deleteli);
            })
        })
        deleteButton.addEventListener('click',function () {
            let deleteList = document.getElementsByClassName('delete-list')[0];
            let deleteli = document.createElement('li');
            deleteli.innerHTML = `<span>To: ${_recipientName}</span><span>Title: ${_title}</span>`
       deleteButton.parentElement.parentElement.remove();
            deleteList.appendChild(deleteli);
        })
    })
    resetButton.addEventListener('click',(ev)=>{
        ev.preventDefault();
        recipientName.value = '';
        title.value = '';
        message.value = '';
    })
}
solve()
