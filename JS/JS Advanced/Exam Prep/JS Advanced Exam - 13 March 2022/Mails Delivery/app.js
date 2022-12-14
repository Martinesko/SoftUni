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

        e.preventDefault();

        let _recipientName = recipientName.value;
        let _title = title.value;
        let _message = message.value;

        let list = document.getElementById('list');
        let li = document.createElement('li');
        let div = document.createElement('div');

        li.innerHTML = `<h4>Title: ${_title}</h4> <h4>Recipient Name: ${_recipientName}</h4> <span>${_message}</span>`;

        let sendButton = document.createElement('button');
        sendButton.setAttribute('type','submit');
        sendButton.setAttribute('id','send');
        sendButton.textContent = 'Send';

        let deleteButton = document.createElement('button');
        deleteButton.setAttribute('type','submit');
        deleteButton.setAttribute('id','delete')
        deleteButton.textContent = 'Delete';

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
           let sentDeleteButton = document.createElement('button');

           sendli.innerHTML = `<span>To: ${_recipientName}</span><span>Title: ${_title}</span>`;

           senddiv.setAttribute('class','btn');
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

                deleteList.appendChild(deleteli);
                sentDeleteButton.parentElement.parentElement.remove();


            })
        })

        deleteButton.addEventListener('click',function () {

            let deleteList = document.getElementsByClassName('delete-list')[0];
            let deleteli = document.createElement('li');

            deleteli.innerHTML = `<span>To: ${_recipientName}</span><span>Title: ${_title}</span>`

            deleteList.appendChild(deleteli);
            deleteButton.parentElement.parentElement.remove();

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
