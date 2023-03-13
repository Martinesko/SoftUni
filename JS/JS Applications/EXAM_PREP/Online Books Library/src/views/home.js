import {html} from "/node_modules/lit-html/lit-html.js";
import{get} from "/src/api/api.js"

const homeTemplate = (data) => html`
    <section id="dashboard-page" class="dashboard">
        <h1>Dashboard</h1>
        <!-- Display ul: with list-items for All books (If any) -->
        ${data.length === 0? html` <p class="no-books">No books in database!</p>`
                : html`
        <ul class="other-books-list">
            ${data.map(x=> template(x))}
        </ul>
`}
    </section>`

function template(book){
    return html`
        <li class="otherBooks">
            <h3>${book.title}</h3>
            <p>Type: ${book.type}</p>
            <p class="img"><img src="${book.imageUrl}"></p>
            <a class="button" href="/details/${book._id}">Details</a>
        </li>
    `
}
export async function showHome(ctx){
    let data = await get("/data/books?sortBy=_createdOn%20desc")
    ctx.render(homeTemplate(data));
}