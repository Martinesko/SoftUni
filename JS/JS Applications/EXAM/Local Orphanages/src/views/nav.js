import {html, render} from "/node_modules/lit-html/lit-html.js";
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";
import {default as page} from '/node_modules/page/page.mjs';

const header = document.getElementsByTagName("header")[0];

const navTemplate = (user) => html`      <!-- Navigation -->
<h1><a href="/">Orphelp</a></h1>

<nav>
    <a href="/">Dashboard</a>

    <!-- Logged-in users -->
    ${user ? html`
    <div id="user">
        <a href="#">My Posts</a>
        <a href="#">Create Post</a>
        <a @click="${onLogout}" href="/">Logout</a>
    </div>
` : html`
    <!-- Guest users -->
    <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>
</nav>
`}
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