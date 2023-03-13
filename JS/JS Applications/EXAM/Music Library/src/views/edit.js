import {html} from "/node_modules/lit-html/lit-html.js";
import {createSubmitHandler} from "/src/api/util.js";
import {get,put} from "/src/api/api.js";

const EditTemplate = (song,onEdit) => html`
    <section id="edit">
        <div class="form">
            <h2>Edit Album</h2>
            <form @submit="${onEdit}" class="edit-form">
                <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" .value="${song.singer}" />
                <input type="text" name="album" id="album-album" placeholder="Album" .value="${song.album}" />
                <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value="${song.imageUrl}" />
                <input type="text" name="release" id="album-release" placeholder="Release date" .value="${song.release}" />
                <input type="text" name="label" id="album-label" placeholder="Label" .value="${song.label}"/>
                <input type="text" name="sales" id="album-sales" placeholder="Sales" .value="${song.sales}"/>

                <button type="submit">post</button>
            </form>
        </div>
    </section>
`

export async function showEdit(ctx){
   const id = ctx.params.id;
    const song = await get(`/data/albums/${id}`);
    ctx.render(EditTemplate(song,createSubmitHandler(onEdit)));
    async function onEdit({singer, album, imageUrl, release, label, sales})
    {
        if (singer === "" || album === "" || imageUrl === "" || release === "" || label === ""|| sales === "") {
            return alert(`All fields are required!`);
        }
        await put(`/data/albums/${id}`, {singer, album, imageUrl, release, label, sales});
        ctx.page.redirect(`/catalog/${id}`);
    }
}