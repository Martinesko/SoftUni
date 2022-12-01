import {html} from "/node_modules/lit-html/lit-html.js";
import {post,get,del} from "/src/api/api.js"
import {createSubmitHandler} from "../api/util.js";

const detailsTemplate = (data,onDelete,isUser,isOwner) => html`
    <section id="details">
        <div id="details-wrapper">
            <img id="details-img" src="${data.imageUrl}" alt="example1" />
            <p id="details-title">${data.title}</p>
            <p id="details-category">
                Category: <span id="categories">${data.category}</span>
            </p>
            <p id="details-salary">
                Salary: <span id="salary-number">${data.salary}</span>
            </p>
            <div id="info-wrapper">
                <div id="details-description">
                    <h4>Description</h4>
                    <span>${data.description}</span>
                </div>
                <div id="details-requirements">
                    <h4>Requirements</h4>
                    <span>${data.requirements}</span>
                </div>
            </div>
            <p>Applications: <strong id="applications">1</strong></p>
            <!--Edit and Delete are only for creator-->
            <div id="action-buttons">
                ${offerController(data,onDelete,isUser,isOwner)}
            </div>
        </div>
    </section>
`
function offerController(data,onDelete,isUser,isOwner){
    if (isOwner){
        return html`
            <a href="/edit/${data._id}" id="edit-btn">Edit</a>
            <a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>
`
    }
    if (isUser){
        return html`
            <a href="" id="apply-btn">Apply</a>
        `
    }
}
export async function showDetails(ctx){

    const id = ctx.params.id;
    const data = await get(`/data/offers/${id}`);
    let isUser = false;
    let isOwner = false;
    if (ctx.user){
        isUser = true;
        if(ctx.user._id === data._ownerId){
            isOwner= true;
        }
    }


    ctx.render(detailsTemplate(data,onDelete,isUser,isOwner));

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete this Offer?`);
        if (choice){
            await del(`/data/offers/${id}`);
            ctx.page.redirect(`/dashboard`);
        }
    }
}

