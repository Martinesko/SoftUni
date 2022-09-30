function addItem() {
    function addItem() {
        let items = document.getElementById('items');
        let textboxvalue = document.getElementById('newItemText').value;
        items.innerHTML += '<li>'+ textboxvalue +'</li>';
    }
}