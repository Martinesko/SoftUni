function attachEvents() {

   let loadPosts = document.getElementById('btnLoadPosts');
   let viewButton = document.getElementById('btnViewPost');
   let posts = document.getElementById('posts');

   loadPosts.addEventListener('click', async function(){
       let postsUrl = `http://localhost:3030/jsonstore/blog/posts`;
       let postsResponse = await fetch(postsUrl);
       let postsData = await postsResponse.json();
       let title = "";
       let body = "";
       let postId = "";

           Object.entries(postsData).forEach(([code,data])=> {

               posts.innerHTML+= `<option value =${code}>${data.title}</option>`;

           })
       viewButton.addEventListener('click',()=>{
           Object.entries(postsData).forEach(([code,data])=> {
            if(posts.value === code){
                title = data.title;
                body = data.body;
                postId = data.postId;
            }
           })


       })
   })
}
attachEvents();