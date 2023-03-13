import {html, nothing} from "/node_modules/lit-html/lit-html.js";
import {get, del} from "/src/api/api.js"

const detailsTemplate = (book, isUser, isOwner, onDelete) => html`
    <section id="details-page" class="details">
        <div class="book-information">
            <h3>${book.title}</h3>
            <p class="type">Type: ${book.type}</p>
            <p class="img"><img src="${book.imageUrl}"></p>
            <div class="actions">
                ${bookController(onDelete, isOwner, isUser, book)}
                <div class="likes">
                    <img class="hearts" src="/images/heart.png">
                    <span id="total-likes">Likes: 0</span>
            </div>
        </div>
        </div>
        <div class="book-description">
            <h3>Description:</h3>
            <p>${book.description}</p>
        </div>
    </section>

`

function bookController(onDelete, isOwner, isUser, book) {
    if (isOwner) {
        return html`
            <a class="button" href="/edit/${book._id}">Edit</a>
            <a class="button" @click="${onDelete}" href="javascript:void(0)">Delete</a>
        
        `
    }
    if (!isOwner) {
        if (isUser) {

            return html`
                <a class="button" href="#">Like</a>
            `
        }
    }
}

export async function showDetails(ctx) {
    const id = ctx.params.id;
    const book = await get(`/data/books/${id}`);
    let isOwner = false;
    let isUser = false;
    if (ctx.user) {
        isUser = true;
        if (book._ownerId === ctx.user._id) {
            isOwner = true;
        }
    }

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete this book?`);
        if (choice) {
            await del(`/data/books/${book._id}`);
            ctx.page.redirect(`/`);
        }
    }

    ctx.render(detailsTemplate(book, isUser, isOwner, onDelete));
}