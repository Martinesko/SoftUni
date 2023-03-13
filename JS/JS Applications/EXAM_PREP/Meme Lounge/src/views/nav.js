import {html, render} from "/node_modules/lit-html/lit-html.js";
import {getUserData} from "../api/util.js";
import {logout} from "../api/user.js";
import {default as page} from '/node_modules/page/page.mjs';

const header = document.getElementsByTagName("header")[0];

const navTemplate = (user) => html`
    <nav>
        <a href="#">All Memes</a>
        <!-- Logged users -->
        <div class="user">
            <a href="#">Create Meme</a>
            <div class="profile">
                <span>Welcome, {email}</span>
                <a href="#">My Profile</a>
                <a href="#">Logout</a>
            </div>
        </div>
        <!-- Guest users -->
        <div class="guest">
            <div class="profile">
                <a href="#">Login</a>
                <a href="#">Register</a>
            </div>
            <a class="active" href="#">Home Page</a>
        </div>
    </nav>
`;

async function onLogout() {
    await logout();
    showNav();
    page.redirect('/');
}

export function showNav() {
    console.log('test')
    let user = getUserData();
    render(navTemplate(user), header);
}