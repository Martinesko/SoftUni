function addItem() {
let newItemText = document.getElementById('newItemText');
let newItemValue = document.getElementById('newItemValue');
let option = document.createElement('option');
let dropDown = document.getElementById('menu');
dropDown.appendChild(option);
option.textContent = newItemText.value;
option.value = newItemValue.value;

newItemText.value = '';
newItemValue.value = '';
}