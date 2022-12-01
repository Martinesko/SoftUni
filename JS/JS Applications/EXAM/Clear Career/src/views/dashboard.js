import {html} from "/node_modules/lit-html/lit-html.js";
import {get} from "../api/api.js";

const dashboardTemplate = (data) => html`
    <section id="dashboard">
        <h2>Job Offers</h2>
        ${data.length === 0 ? html`
            <h2>No offers yet.</h2> 
        ` : data.map(x=> template(x))};
    </section>

`
function template(offer) {
    return html`<div class="offer">
        <img src="${offer.imageUrl}" alt="example1" />
        <p>
            <strong>Title: </strong><span class="title">${offer.title}</span>
        </p>
        <p><strong>Salary:</strong><span class="salary">${offer.salary}</span></p>
        <a class="details-btn" href="/dashboard/${offer._id}">Details</a>
    </div>`
}

export async function showDashboard(ctx){
    let data = await get("/data/offers?sortBy=_createdOn%20desc");
    ctx.render(dashboardTemplate(data));
}

