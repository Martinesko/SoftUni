import {html} from "/node_modules/lit-html/lit-html.js";
import {createSubmitHandler} from "../api/util.js";
import {get, post,put} from "../api/api.js";

const EditTemplate = (card,onEdit) => html`<section id="edit">
          <div class="form">
            <h2>Edit item</h2>
            <form @submit="${onEdit}" class="edit-form">
              <input
                type="text"
                name="brand"
                id="shoe-brand"
                placeholder="Brand"
                value="${card.brand}"
              />
              <input
                type="text"
                name="model"
                id="shoe-model"
                placeholder="Model"
                value="${card.model}"
              />
              <input
                type="text"
                name="imageUrl"
                id="shoe-img"
                placeholder="Image url"
                value="${card.imageUrl}"
              />
              <input
                type="text"
                name="release"
                id="shoe-release"
                placeholder="Release date"
                value="${card.release}"
              />
              <input
                type="text"
                name="designer"
                id="shoe-designer"
                placeholder="Designer"
                value="${card.designer}"
              />
              <input
                type="text"
                name="value"
                id="shoe-value"
                placeholder="Value"
                value="${card.value}"
              />

              <button type="submit">post</button>
            </form>
          </div>
        </section>

`

export async function showEdit(ctx){

   const id = ctx.params.id;
    const card = await get(`/data/shoes/${id}`);
    ctx.render(EditTemplate(card,createSubmitHandler(onEdit)));
    async function onEdit({brand,model,imageUrl,release,designer,value}){
        if(brand === "" || model === "" || imageUrl === "" || release === "" || designer === "" || value === ""){
            return alert("All field are required!");
        }
        await put(`/data/shoes/${id}`, {brand,model,imageUrl,release,designer,value});
        ctx.page.redirect(`/catalog/${id}`);
    }
}