import {html} from "/node_modules/lit-html/lit-html.js";
import{get} from "/src/api/api.js"

const catalogTemplate = (data) => html`
    <section id="dashboard">
        <h2>Collectibles</h2>
        <ul class="card-wrapper">
${data.length===0 ? html` <h2>There are no items added yet.</h2>`:
        data.map(x=>template(x))}          
        </ul>

        <!-- Display an h2 if there are no posts -->
       
    </section>
`

function template(card){
    return html`
        <li class="card">
            <img src="${card.imageUrl}" alt="travis" />
            <p>
                <strong>Brand: </strong><span class="brand">${card.brand}</span>
            </p>
            <p>
                <strong>Model: </strong
                ><span class="model">${card.model}</span>
            </p>
            <p><strong>Value:</strong><span class="value">${card.value}</span>$</p>
            <a class="details-btn" href="/catalog/${card._id}">Details</a>
        </li>
    `
}
export async function showCatalog(ctx){
 let data = await get("/data/shoes?sortBy=_createdOn%20desc")
    ctx.render(catalogTemplate(data));
}