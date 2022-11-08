async function solution() {
    let main = document.getElementById('main');
    let buttons = document.getElementsByClassName('button');

    let listUrl = "http://localhost:3030/jsonstore/advanced/articles/list";
    let listResponse = await fetch(listUrl);
    let listData = await listResponse.json();
    for (const data of listData) {
        let detailsUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${data._id}`;
        let detailsResponse = await fetch(detailsUrl);
        let detailsData = await detailsResponse.json();
            main.innerHTML+= `<div class="accordion"><div class="head"><span>${detailsData.title}</span><button class="button" id=${data._id}>More</button></div><div class="extra"><p>${detailsData.content}</p></div></div>`
        }
    for (const button of buttons) {
        let acordition = button.parentElement.parentElement;
        let extra = acordition.getElementsByClassName('extra')[0];
        button.addEventListener("click",()=>{
            if (button.textContent === "More"){

                button.textContent = "Less"
                extra.style.display = "block";

            }
            else {

                button.textContent = "More";
                extra.style.display = 'none';

            }
        })
    }
}