import {showHome} from "./views/home.js";
import {showNav} from "./views/nav.js";
import {getUserData} from "./api/util.js";
import {render} from "/node_modules/lit-html/lit-html.js";
import {default as page} from '/node_modules/page/page.mjs';
import {showLogin} from "./views/login.js";
import {showRegister} from "./views/register.js";
import {showCatalog} from "./views/catalog.js";
import {showDetails} from "./views/details.js";
import {showCreate} from "./views/create.js";
import {showEdit} from "./views/edit.js";

const main = document.getElementById('main-content');

page(decorateContext)
page(`/`, showHome);
page(`/login`,showLogin)
page(`/register`,showRegister)
page('/create',showCreate)
page('/catalog',showCatalog)
page('/details/:id',showDetails)
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
    render(content,main)
}