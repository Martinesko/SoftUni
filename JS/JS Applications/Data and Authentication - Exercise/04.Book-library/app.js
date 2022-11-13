async function solve(){
    let button = document.getElementsByTagName('form')[0].getElementsByTagName('button')[0];
    button.addEventListener("click", async(e)=>{
        e.preventDefault();
        if(button.textContent === 'Submit') {
            let form = document.getElementsByTagName("form")[0];
            let data = new FormData(form);
            let {title, author} = Object.fromEntries(new FormData(form).entries());
            if (title.contains('')){
                return;
            }
            if (author.contains('')){
                return;
            }

        }
    })
}
solve();