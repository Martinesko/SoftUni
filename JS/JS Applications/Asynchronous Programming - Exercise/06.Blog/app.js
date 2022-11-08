function attachEvents() {

   let loadPosts = document.getElementById('btnLoadPosts');
   let posts = document.getElementById('posts');

   loadPosts.addEventListener('click', async function(){
       let postsUrl = `http://localhost:3030/jsonstore/blog/posts`;
       let postsResponse = await fetch(postsUrl);
       let postsData = await postsResponse.json();
       Object.entries(postsData).forEach([])
       for (const postData of postsData) {
           let option = document.createElement('option');
           option.textContent = postData.title;
           option.value = postData.data;
            posts.appendChild(option);
       }
   })
}
attachEvents();