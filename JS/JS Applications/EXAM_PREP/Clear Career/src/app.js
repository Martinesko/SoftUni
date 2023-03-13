import {getUserData} from "/src/api/util.js";
import {render} from "/node_modules/lit-html/lit-html.js";
import {default as page} from '/node_modules/page/page.mjs';
import {showHome} from "/src/views/home.js";
import {showNav} from "/src/views/nav.js";
import {showLogin} from "./views/login.js";
import {showRegister} from "./views/register.js";
import {showDashboard} from "./views/dashboard.js";
import {showCreate} from "./views/create.js";
import {showDetails} from "./views/details.js";
import {showEdit} from "./views/edit.js";

const main = document.getElementById('content');

page(decorateContext)
page(`/`, showHome);
page('/login',showLogin)
page('/register',showRegister)
page('/dashboard',showDashboard)
page('/create',showCreate)
page('/dashboard/:id',showDetails)
page('/edit/:id',showEdit)
page.start();
showNav();


function decorateContext(ctx,next) {
    ctx.render = renderMain;
    ctx.updateNav = showNav;
    ctx.user = getUserData();
    next();
}

function renderMain(content) {
    render(content,main);
}