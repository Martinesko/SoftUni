import {html, render} from "/node_modules/lit-html/lit-html.js";
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";
import {default as page} from '/node_modules/page/page.mjs';

const header = document.getElementsByTagName("header")[0];
const navTemplate = (user) => html`
    <a id="logo" href="/">
        <img id="logo-img" src="/images/logo.jpg" alt=""/>
    </a>
    <nav>
        <div>
            <a href="/dashboard">Dashboard</a>
        </div>
        <!-- Logged-in users -->

        <!-- Guest users -->
        ${!user ? html`
                    <div class="guest">
                        <a href="/login">Login</a>
                        <a href="/register">Register</a>
                    </div>` :
                html
                        `
                            <div class="user">
                                <a href="/create">Create Offer</a>
                                <a @click="${onLogout}"href="javascript:void(0)">Logout</a>
                            </div>
                        `}
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