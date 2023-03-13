import {html, render} from "/node_modules/lit-html/lit-html.js";
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";
import {default as page} from '/node_modules/page/page.mjs';

const header = document.getElementsByTagName('header')[0];

const navTemplate = (user) => html`
    <a id="logo" href="/"><img id="logo-img" src="./images/logo.png" alt="" /></a>

    <nav>
        <div>
            <a href="/catalog">Dashboard</a>
        </div>

      ${!user ? html`<div class="guest">
          <a href="/login">Login</a>
          <a href="/register">Register</a>
      </div>`: html` <div class="user">
          <a href="/create">Add Album</a>
          <a @click="${onLogout}"href="javascript:void(0)">Logout</a>
      </div>`}
        
    </nav>
    </header>
`;

async function onLogout() {
    await logout();
    showNav();
    page.redirect('/');
}

export function showNav() {
    let user = getUserData();
    render(navTemplate(user), header);
}