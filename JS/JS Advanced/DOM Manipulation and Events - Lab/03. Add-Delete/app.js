function addItem() {
            let items = document.getElementById('items');
            let textboxvalue = document.getElementById('newItemText').value;
            let deleteButton = document.createElement('a');

            let li = document.createElement('li');
            li.textContent =  textboxvalue;

            deleteButton.href = "#";
            deleteButton.textContent = '[Delete]';


            deleteButton.addEventListener('click',function (event){event.target.parentElement.remove()});
            li.appendChild(deleteButton);
            items.appendChild(li);
}