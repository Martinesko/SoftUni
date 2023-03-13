import {html,nothing} from "/node_modules/lit-html/lit-html.js";
import{get,del} from "/src/api/api.js"

const detailsTemplate = (pet,isUser,isOwner,onDelete) => html`
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${pet.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${pet.name}</h1>
                    <h3>Breed: ${pet.breed}</h3>
                    <h4>Age: ${pet.age}</h4>
                    <h4>Weight: ${pet.weight}</h4>
                    <h4 class="donation">Donation: 0$</h4>
                </div>
            
                <div class="actionBtn">
                 
                    ${petController(onDelete,isOwner,isUser,pet)}
                    
                </div>
            </div>
        </div>
    </section>
    </main>

`

function petController(onDelete,isOwner,isUser,pet){
    if (isOwner){
        return html`
            
               <a href="/edit/${pet._id}" class="edit">Edit</a>
                <a @click="${onDelete}" href="javascript:void(0)" class="remove">Delete</a>
`
    }
    if (isUser){
        return html`
            <!--<a href="#" class="donate">Donate</a>-->
        `
    }
}

export async function showDetails(ctx){
    const id = ctx.params.id;
    const pet = await get(`/data/pets/${id}`);
    let isOwner = false;
    let isUser = false;
    if(pet._ownerId === ctx.user._id){
        isOwner = true;
    }
    if(ctx.user){
        isUser = true;
    }

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete this pet?`);
        if (choice){

            await del(`/data/pets/${id}`);
            ctx.page.redirect(`/`);
        }
    }

    ctx.render(detailsTemplate(pet,isUser,isOwner,onDelete));

}