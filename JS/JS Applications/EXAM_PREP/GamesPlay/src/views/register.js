import {html} from "/node_modules/lit-html/lit-html.js";
import {createSubmitHandler} from "../api/util.js";
import {register} from "../api/user.js";

const registerTemplate = (onRegister) => html`
    <section id="register-page" class="content auth">
        <form id="register">
            <div class="container">
                <div class="brand-logo"></div>
                <h1>Register</h1>

                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="maria@email.com">

                <label for="pass">Password:</label>
                <input type="password" name="password" id="register-password">

                <label for="con-pass">Confirm Password:</label>
                <input type="password" name="confirm-password" id="confirm-password">

                <input class="btn submit" type="submit" value="Register">

                <p class="field">
                    <span>If you already have profile click <a href="#">here</a></span>
                </p>
            </div>
        </form>
    </section>

`

export function showRegister(ctx){
    ctx.render(registerTemplate(createSubmitHandler(onRegister)));

    async function onRegister(data){
        const email = data["email"];
        const password = data["password"];
        const repeatPassword = data["confirm-pass"];
        if(email === "" || password === ""|| repeatPassword === ""){
            return alert("All fields are required!");
        }
        if (password !== repeatPassword){
            return alert("Password does not match");
        }
        await register(email,password);
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}