import {html} from "/node_modules/lit-html/lit-html.js";
import{get,del} from "/src/api/api.js"

const detailsTemplate = (song,isUser,isOwner,onDelete) => html`
     <section id="details">
        <div id="details-wrapper">
          <p id="details-title">Album Details</p>
          <div id="img-wrapper">
            <img src="${song.imageUrl}" alt="example1" />
          </div>
          <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${song.singer}</span></p>
            <p>
              <strong>Album name:</strong><span id="details-album">${song.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${song.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${song.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${song.sales}</span></p>
          </div>
          <div id="likes">Likes: <span id="likes-count">0</span></div>
          <!--Edit and Delete are only for creator-->
          <div id="action-buttons">
           ${songController(onDelete,isOwner,isUser,song)}
          </div>
        </div>
      </section>
`

function songController(onDelete,isOwner,isUser,song){
    if (isOwner){
        return html`
            <a href="/edit/${song._id}" id="edit-btn">Edit</a>
            <a @click="${onDelete}" href="javascript:void(0)" id="delete-btn">Delete</a>
`
    }
    if (isUser){
        return html`
            <a href="" id="like-btn">Like</a>
        `
    }
}

export async function showDetails(ctx){
    const id = ctx.params.id;
    const song = await get(`/data/albums/${id}`);
    let isOwner = false;
    let isUser = false;
    if(song._ownerId === ctx.user._id){
        isOwner = true;
    }
    if(ctx.user){
        isUser = true;
    }

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete this song?`);
        if (choice){

            await del(`/data/albums/${id}`);
            ctx.page.redirect(`/`);
        }
    }

    ctx.render(detailsTemplate(song,isUser,isOwner,onDelete));

}