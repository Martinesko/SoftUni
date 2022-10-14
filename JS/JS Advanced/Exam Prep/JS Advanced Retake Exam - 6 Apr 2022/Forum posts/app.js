window.addEventListener("load", solve)

function solve() {
    let postTitle = document.getElementById('post-title');
    let postCategory = document.getElementById('post-category');
    let postContent = document.getElementById('post-content');
    let postButton = document.getElementById('publish-btn');
    let clearButton = document.getElementById('clear-btn');
    postButton.addEventListener('click', (ev) => {
        ev.preventDefault();
        let _postTitle = postTitle.value;
        let _postCategory = postCategory.value;
        let _postContent = postContent.value;
        if (postTitle.value === '' || postCategory.value === '' || postContent.value === '') {
            return;
        }
        let editButton = document.createElement('button');
        let approveButton = document.createElement('button');
        editButton.setAttribute('class', 'action-btn edit');
        approveButton.setAttribute('class', 'action-btn approve');
        editButton.textContent = 'Edit';
        approveButton.textContent = 'Approve';

        let reviewList = document.getElementById('review-list');
        let li = document.createElement('li');
        li.setAttribute('class', 'rpost');
        li.innerHTML = `<article><h4>${_postTitle}</h4><p>Category: ${_postCategory}</p><p>Content: ${_postContent}</p></article>`;
        li.appendChild(editButton);
        li.appendChild(approveButton);
        reviewList.appendChild(li);

        postTitle.value = '';
        postCategory.value = '';
        postContent.value = '';
        editButton.addEventListener('click', function () {
            postTitle.value = _postTitle;
            postCategory.value = _postCategory;
            postContent.value = _postContent;
            editButton.parentElement.remove();
        })
        approveButton.addEventListener('click', function () {
            let uploadedList = document.getElementById('published-list');
            let liOutput = document.createElement('li');
            liOutput.setAttribute('class', 'rpost');
            liOutput.innerHTML = `<article><h4>${_postTitle}</h4><p>Category: ${_postCategory}</p><p>Content: ${_postContent}</p></article>`;
            uploadedList.appendChild(liOutput);
            editButton.parentElement.remove();
        })
        clearButton.addEventListener('click', function () {
            let uploadedList = document.getElementById('published-list');
            let ul = document.createElement('ul');
            ul.setAttribute('id', 'published-list');
            uploadedList.innerHTML = ul.innerHTML;

        })
    })
}
