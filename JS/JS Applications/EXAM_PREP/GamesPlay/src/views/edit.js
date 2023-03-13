import {html} from "/node_modules/lit-html/lit-html.js";
import {createSubmitHandler} from "../api/util.js";
import {get, post,put} from "../api/api.js";

const EditTemplate = (book,onEdit) => html` <section id="edit-page" class="auth">
            <form id="edit">
                <div class="container">

                    <h1>Edit Game</h1>
                    <label for="leg-title">Legendary title:</label>
                    <input type="text" id="title" name="title" value="">

                    <label for="category">Category:</label>
                    <input type="text" id="category" name="category" value="">

                    <label for="levels">MaxLevel:</label>
                    <input type="number" id="maxLevel" name="maxLevel" min="1" value="">

                    <label for="game-img">Image:</label>
                    <input type="text" id="imageUrl" name="imageUrl" value="">

                    <label for="summary">Summary:</label>
                    <textarea name="summary" id="summary"></textarea>
                    <input class="btn submit" type="submit" value="Edit Game">

                </div>
            </form>
        </section>

`

export async function showEdit(ctx){
   const id = ctx.params.id;
    const book = await get(`/data/books/${id}`);

    async function onEdit({title,description,imageUrl,type}){
        if (title === "" || description === "" || imageUrl === "" || type === "") {
            return alert(`All fields are required!`);
        }
        await put(`/data/books/${id}`, {title,description,imageUrl,type});
        ctx.page.redirect(`/details/${id}`);
    }
    ctx.render(EditTemplate(book,createSubmitHandler(onEdit)));
}