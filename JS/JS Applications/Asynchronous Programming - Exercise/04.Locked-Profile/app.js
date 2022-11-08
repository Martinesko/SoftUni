async function lockedProfile() {
    let main = document.getElementById(`main`);
    let profiles = document.getElementsByClassName('profile');

    let profilesUrl = "http://localhost:3030/jsonstore/advanced/profiles";
    let response = await fetch(profilesUrl);
    let profilesData = await response.json();

Object.entries(profilesData).forEach(([id,profileData]) =>{
    main.innerHTML += `<div class="profile">
    <img src="./iconProfile2.png" class="userIcon" />
    <label>Lock</label>
    <input type="radio" name="user1Locked" value="lock" checked>
    <label>Unlock</label>
    <input type="radio" name="user1Locked" value="unlock"><br>
    <hr>
    <label>Username</label>
    <input type="text" name="user1Username" value="${profileData.username}" disabled readonly />
    <div class="user1Username" style="display: none">
        <hr>
        <label>Email:</label>
        <input type="email" name="user1Email" value="${profileData.email}" disabled readonly />
        <label>Age:</label>
        <input type="email" name="user1Age" value="${profileData.age}" disabled readonly />
</div>
<button>Show more</button>
</div>`
})
    for (const profile of profiles) {
        let unlock = profile.children.item(4);
        console.log(unlock)
        let button = profile.getElementsByTagName('button')[0];
        let information = profile.getElementsByClassName('user1Username')[0];
        button.addEventListener("click", () => {
            if (unlock.checked === true) {

                if (button.textContent === "Show more") {

                    button.textContent = "Hide it";
                    information.style.display = "block";

                }

                else if (button.textContent === "Hide it"){

                    button.textContent = "Show more";
                    information.style.display = "none";

                }
                else {
                    button.textContent = "Hide it";
                    button.disabled = false;
                }
            }
        })

    }
}
