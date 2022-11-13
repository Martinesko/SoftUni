async function attachEvents() {
    let messagesBox = document.getElementById('messages');
    let submitBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');

    submitBtn.addEventListener('click',async ()=>{
        let author = document.getElementsByName('author')[0];
        let content = document.getElementsByName('content')[0];
        const object = {'author':author.value,'content':content.value};
        await fetch('http://localhost:3030/jsonstore/messenger', {
                method:'post',
                headers:{'Content-type': 'application/json'},
                body:JSON.stringify(object)
        })
        author.value = '';
        content.value = '';
    })
    refreshBtn.addEventListener('click',async ()=>{
        let messagesResponse = await fetch('http://localhost:3030/jsonstore/messenger');
        let messagesData = await messagesResponse.json();
        messagesBox.textContent = '';
        let output = [];
    Object.entries(messagesData).forEach(([id,message])=>{
    output.push(`${message.author}:${message.content}`);
    })
        messagesBox.textContent += output.join('\n');
})

}

attachEvents();