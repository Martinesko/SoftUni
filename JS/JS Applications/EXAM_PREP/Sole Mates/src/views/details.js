import {html,nothing} from "/node_modules/lit-html/lit-html.js";
import{get,del} from "/src/api/api.js"

const detailsTemplate = (card,isUser,isOwner,onDelete) => html`
     <section id="details">
          <div id="details-wrapper">
            <p id="details-title">Shoe Details</p>
            <div id="img-wrapper">
              <img src="${card.imageUrl}" alt="example1" />
            </div>
            <div id="info-wrapper">
              <p>Brand: <span id="details-brand">${card.brand}</span></p>
              <p>
                Model: <span id="details-model">${card.model}</span>
              </p>
              <p>Release date: <span id="details-release">${card.release}</span></p>
              <p>Designer: <span id="details-designer">${card.designer}</span></p>
              <p>Value: <span id="details-value">${card.value}</span></p>
            </div>   
              ${cardController(onDelete,isOwner,isUser,card)}
          </div>
  
        </section>
`

function cardController(onDelete,isOwner,isUser,card){
    if (isOwner){
        return html`
            <div id="action-buttons">
                <a href="/edit/${card._id}" id="edit-btn">Edit</a>
                <a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>
            </div>
`
    }
}

export async function showDetails(ctx){
    const id = ctx.params.id;
    const card = await get(`/data/shoes/${id}`);
    let isOwner = false;
    let isUser = false;

    if(ctx.user){
        isUser = true;
        if(card._ownerId === ctx.user._id){
            isOwner = true;
        }
    }

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete this card?`);
        if (choice){
            await del(`/data/shoes/${id}`);
            ctx.page.redirect(`/catalog`);
        }
    }

    ctx.render(detailsTemplate(card,isUser,isOwner,onDelete));

}