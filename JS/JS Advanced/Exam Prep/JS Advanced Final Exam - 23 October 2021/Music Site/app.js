window.addEventListener('load', solve);

function solve() {
    let genre = document.getElementById('genre');
    let name = document.getElementById('name');
    let author = document.getElementById('author');
    let date = document.getElementById('date');
    let likeCounter = document.getElementsByClassName('likes')[0];
    let addButton = document.getElementById('add-btn');
    let likes = 0;

    addButton.addEventListener('click', (ev)=> {
        ev.preventDefault();
        let _genre = genre.value;
        let _name = name.value;
        let _author = author.value;
        let _date = date.value;
        if(_genre === ''||_name === ''||_author === ''|| _date  ===''){
                return;
            }
            let allHits = document.getElementsByClassName('all-hits-container')[0];

            let div = document.createElement('div');
            div.setAttribute('class','hits-info');

            let saveButton = document.createElement('button');
            let likeButton = document.createElement('button');
            let deleteButton = document.createElement('button');
            saveButton.setAttribute('class','save-btn');
            likeButton.setAttribute('class','like-btn');
            deleteButton.setAttribute('class','delete-btn');

            saveButton.textContent = 'Save song';
            likeButton.textContent = 'Like song';
            deleteButton.textContent = 'Delete';

            div.innerHTML = `<img src ="./static/img/img.png"><h2>Genre: ${_genre}</h2><h2>Name: ${_name}</h2><h2>Author: ${_author}</h2><h3>Date: ${_date}</h3>`;

            div.appendChild(saveButton);
            div.appendChild(likeButton);
            div.appendChild(deleteButton);
            allHits.appendChild(div);
            genre.value = '';
            name.value = '';
            author.value = '';
            date.value = '';
            likeButton.addEventListener('click',function () {
                likes++;
                likeCounter.innerHTML = ` <p>Total Likes: ${likes}</p><img src="./static/img/like-btn.jpg" alt="image-like">`
                likeButton.disabled = 'true';
            })
            deleteButton.addEventListener('click',function (){
                deleteButton.parentElement.remove();
            })
        saveButton.addEventListener('click',function () {
            let savedSongs = document.getElementsByClassName('saved-container')[0];
            let newdiv = document.createElement('div');
            newdiv.setAttribute('class','hits-info')
            let deleteButton2 = document.createElement('button');
            deleteButton2.setAttribute('class','delete-btn');
            newdiv.innerHTML = `<img src ="./static/img/img.png"><h2>Genre: ${_genre}</h2><h2>Name: ${_name}</h2><h2>Author: ${_author}</h2><h3>Date: ${_date}</h3>`;
            newdiv.appendChild(deleteButton2);
            savedSongs.appendChild(newdiv);
            saveButton.parentElement.remove();
            deleteButton2.textContent = 'Delete';
            deleteButton2.addEventListener('click',function () {
                deleteButton2.parentElement.remove();
            })
        })
        })
}