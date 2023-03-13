import {html} from "/node_modules/lit-html/lit-html.js";
import {createSubmitHandler} from "../api/util.js";
import {login} from "../api/user.js";

const loginTemplate = (onLogin) => html`
    <section id="login-page" class="auth">
        <form id="login">

            <div class="container">
                <div class="brand-logo"></div>
                <h1>Login</h1>
                <label for="email">Email:</label>
                <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

                <label for="login-pass">Password:</label>
                <input type="password" id="login-password" name="password">
                <input type="submit" class="btn submit" value="Login">
                <p class="field">
                    <span>If you don't have profile click <a href="#">here</a></span>
                </p>
            </div>
        </form>
    </section>

`

export function showLogin(ctx){
    ctx.render(loginTemplate(createSubmitHandler(onLogin)));

    async function onLogin({email,password}){
        if(email === "" || password === ""){
            return alert("All fields are required!");
        }
        await login(email,password);
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}