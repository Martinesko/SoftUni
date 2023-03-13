import {html} from "/node_modules/lit-html/lit-html.js";
import{get} from "/src/api/api.js"

const homeTemplate = (data) => html`
    <section id="welcome-world">

        <div class="welcome-message">
            <h2>ALL new games are</h2>
            <h3>Only in GamesPlay</h3>
        </div>
        <img src="./images/four_slider_img01.png" alt="hero">

        <div id="home-page">
            <h1>Latest Games</h1>

            <!-- Display div: with information about every game (if any) -->
            <div class="game">
                <div class="image-wrap">
                    <img src="./images/CoverFire.png">
                </div>
                <h3>Cover Fire</h3>
                <div class="rating">
                    <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
                </div>
                <div class="data-buttons">
                    <a href="#" class="btn details-btn">Details</a>
                </div>
            </div>
            <div class="game">
                <div class="image-wrap">
                    <img src="./images/ZombieLang.png">
                </div>
                <h3>Zombie Lang</h3>
                <div class="rating">
                    <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
                </div>
                <div class="data-buttons">
                    <a href="#" class="btn details-btn">Details</a>
                </div>
            </div>
            <div class="game">
                <div class="image-wrap">
                    <img src="./images/MineCraft.png">
                </div>
                <h3>MineCraft</h3>
                <div class="rating">
                    <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
                </div>
                <div class="data-buttons">
                    <a href="#" class="btn details-btn">Details</a>
                </div>
            </div>

            <!-- Display paragraph: If there is no games  -->
            <p class="no-articles">No games yet</p>
        </div>
    </section>
`

function template(book){
    return html`
        <li class="otherBooks">
            <h3>${book.title}</h3>
            <p>Type: ${book.type}</p>
            <p class="img"><img src="${book.imageUrl}"></p>
            <a class="button" href="/details/${book._id}">Details</a>
        </li>
    `
}
export async function showHome(ctx){
    let data = await get("/data/books?sortBy=_createdOn%20desc")
    ctx.render(homeTemplate(data));
}