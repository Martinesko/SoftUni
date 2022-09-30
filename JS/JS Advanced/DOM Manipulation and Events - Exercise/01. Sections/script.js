function create(words) {
  let result = document.getElementById('content');
  for (let word of words) {
     let div = document.createElement('div');
     let p = document.createElement('p');
     p.style.display = 'none';
     div.appendChild(p);
     div.addEventListener('click' , function (event){
        p.style.display = 'block';
     } )
     result.appendChild(div);
  }


}