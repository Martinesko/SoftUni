function lockedProfile() {
    let buttons = document.getElementsByTagName('button');
    for (const button of buttons) {
        button.addEventListener('click', function (){
            let person = button.parentElement;
                let lock = person.children.item(4);
            let information = person.children.item(9);
            if (lock.checked == true){
                if (button.textContent == 'Show more'){
                    button.textContent = 'Hide it';
                    information.style.display = 'block';
                }
                else if (button.textContent == 'Hide it'){
                    information.style.display = 'none';
                    button.textContent == 'Show more';
                }
            }
            else{
                button.disabled = false;
            }

        })
    }


}