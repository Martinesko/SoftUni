import {html} from "/node_modules/lit-html/lit-html.js";
import {post} from "/src/api/api.js"
import {createSubmitHandler} from "../api/util.js";

const createTemplate = (onCreate) => html`
    <section id="create">
        <div @submit="${onCreate}" class="form">
            <h2>Create Offer</h2>
            <form class="create-form">
                <input
                        type="text"
                        name="title"
                        id="job-title"
                        placeholder="Title"
                />
                <input
                        type="text"
                        name="imageUrl"
                        id="job-logo"
                        placeholder="Company logo url"
                />
                <input
                        type="text"
                        name="category"
                        id="job-category"
                        placeholder="Category"
                />
                <textarea
                        id="job-description"
                        name="description"
                        placeholder="Description"
                        rows="4"
                        cols="50"
                ></textarea>
                <textarea
                        id="job-requirements"
                        name="requirements"
                        placeholder="Requirements"
                        rows="4"
                        cols="50"
                ></textarea>
                <input
                        type="text"
                        name="salary"
                        id="job-salary"
                        placeholder="Salary"
                />

                <button type="submit">post</button>
            </form>
        </div>
    </section>
`

export function showCreate(ctx){
    ctx.render(createTemplate(createSubmitHandler(onCreate)));

    async function onCreate({title, imageUrl, category, description, requirements, salary}){
        if(title === "" ||imageUrl === "" ||category === "" || description === "" ||requirements === "" ||salary === ""){
            return alert("All fields are required!");
        }
         await post(`/data/offers`,{
                 title,
                 imageUrl,
                 category,
                 description,
                 requirements,
                 salary
             }
         );
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}

