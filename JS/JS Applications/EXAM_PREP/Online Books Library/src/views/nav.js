import {html, render} from "/node_modules/lit-html/lit-html.js";
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";
import {default as page} from '/node_modules/page/page.mjs';

const header = document.getElementById('site-header');

const navTemplate = (user) => html`
    <nav class="navbar">
        <section class="navbar-dashboard">
            <a href="/">Dashboard</a>
           ${!user ? html` <div id="guest">
                <a class="button" href="/login">Login</a>
                <a class="button" href="/register">Register</a>
            </div>` : html` <div id="user">
               <span>Welcome, ${user.email}</span>
               <a class="button" href="/catalog">My Books</a>
               <a class="button" href="/create">Add Book</a>
               <a class="button" @click="${onLogout}"href="javascript:void(0)">Logout</a>
           </div>`}
</section>
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