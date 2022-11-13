async function solve() {
    debugger;
    await display();
    let form = document.getElementById('form');
    form.addEventListener('submit', async (e) => {
        e.preventDefault();
        debugger;
        let data = new FormData(form);
        const studentObject = Object.fromEntries(data.entries());
        if (Object.values(studentObject).includes("")) {
            return;
        }
        await fetch(`http://localhost:3030/jsonstore/collections/students`, {
            method: `POST`,
            headers: {"Content-type": `application/json`},
            body: JSON.stringify(studentObject)
        });
        await display();
    })



    async function display() {
        let peopleResponse = await fetch('http://localhost:3030/jsonstore/collections/students');
        let peopleData = await peopleResponse.json();
        let tbody = document.getElementById('results').getElementsByTagName('tbody')[0];
        tbody.innerHTML = '';
        Object.entries(peopleData).forEach(([id, person]) => {
            tbody.innerHTML += `<tr><td>${person.firstName}</td><td>${person.lastName}</td><td>${person.facultyNumber}</td><td>${person.grade}</td></tr>`;
        })
    }
}
solve()