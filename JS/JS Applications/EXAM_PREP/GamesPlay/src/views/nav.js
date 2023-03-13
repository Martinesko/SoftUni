import {html, render} from "/node_modules/lit-html/lit-html.js";
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";
import {default as page} from '/node_modules/page/page.mjs';

const header = document.getElementById('site-header');

const navTemplate = (user) => html`
    <h1><a class="home" href="#">GamesPlay</a></h1>
    <nav>
        <a href="#">All games</a>
        <!-- Logged-in users -->
        <div id="user">
            <a href="#">Create Game</a>
            <a href="#">Logout</a>
        </div>
        <!-- Guest users -->
        <div id="guest">
            <a href="#">Login</a>
            <a href="#">Register</a>
        </div>
    </nav>
`

async function onLogout() {
    await logout();
    showNav();
    page.redirect('/');
}

export function showNav() {
    let user = getUserData();
    render(navTemplate(user), header);
}