import {html} from "/node_modules/lit-html/lit-html.js";
import{get} from "/src/api/api.js"

const catalogTemplate = (data) => html`
    <section id="dashboard">
        <h2>Albums</h2>
        <ul class="card-wrapper">
           ${data.length === 0 ? html`<h2>There are no albums added yet.</h2>` : html`${data.map(x=>template(x))}`}
        </ul>

        <!-- Display an h2 if there are no posts -->
        
    </section>
`

function template(song){
    return html`
        <li class="card">
            <img src="${song.imageUrl}" alt="travis" />
            <p>
                <strong>Singer/Band: </strong><span class="singer">${song.singer}</span>
            </p>
            <p>
                <strong>Album name: </strong><span class="album">${song.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${song.sales}</span></p>
            <a class="details-btn" href="/catalog/${song._id}">Details</a>
        </li>
    `
}
export async function showCatalog(ctx){
 let data = await get("/data/albums?sortBy=_createdOn%20desc")
    ctx.render(catalogTemplate(data));
}