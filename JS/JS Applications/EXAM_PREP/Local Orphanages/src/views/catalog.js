import {html} from "/node_modules/lit-html/lit-html.js";
import{get} from "/src/api/api.js"

const catalogTemplate = (data) => html`
   <section id="my-books-page" class="my-books">
    <h1>My Books</h1>
                  ${data.length === 0 ?
                   html`<p class="no-books">No books in database!</p>` :
                   html` <ul class="my-books-list">
                  ${data.map(x=>template(x))}</ul>
              `}`

function template(book){
    return html`
        <li class="otherBooks">
            <h3>${book.title}</h3>
            <p>Type: ${book.type}</p>
            <p class="img"><img src="${book.imageUrl}""></p>
            <a class="button" href="/details/${book._id}">Details</a>
        </li>
    `
}
export async function showCatalog(ctx){
 let books = await get(`/data/books?where=_ownerId%3D%22${ctx.user._id}%22&sortBy=_createdOn%20desc`)
    ctx.render(catalogTemplate(books));
}