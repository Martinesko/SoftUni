import {showHome} from "/src/views/home.js";
import {showNav} from "/src/views/nav.js";
import {getUserData} from "/src/api/util.js";
import {render} from "/node_modules/lit-html/lit-html.js";
import {default as page} from '/node_modules/page/page.mjs';
import {showLogin} from "/src/views/login.js";
import {showRegister} from "/src/views/register.js";
import {showCatalog} from "/src/views/catalog.js";
import {showDetails} from "/src/views/details.js";
import {showCreate} from "/src/views/create.js";
import {showEdit} from "/src/views/edit.js";

const main = document.getElementById('container');

page(decorateContext)
page(`/`, showHome);
page(`/login`,showLogin)
page(`/register`,showRegister)
page('/create',showCreate)
page('/catalog',showCatalog)
page('/catalog/:id',showDetails)
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