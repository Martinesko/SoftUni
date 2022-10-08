function solve() {
    let button = document.getElementsByTagName('button')[0];
    let list = document.querySelector('tbody');
    button.addEventListener('click' , function () {
        let products = JSON.parse(document.getElementsByTagName('textarea')[0].value);
        for (const product of products) {
            let tr = document.createElement('tr');
            tr.innerHTML = `<td><img src="${product.img}"><td><p>${product.name}</p><td><p>${product.price}</p><td><p>${product.decFactor}</p><td><input type="checkbox"/></td>`;
            list.appendChild(tr);
            document.getElementsByTagName('textarea')[0].value = '';
        }
    })

    let sellButton = document.getElementsByTagName('button')[1];
    sellButton.addEventListener('click',function () {
        let bought = [];
        for (const product of Array.from(list.children)) {
            if (product.getElementsByTagName('input')[0].checked == true){
                let info = product.querySelectorAll('p');
                let name = info[0].textContent;
                let price = Number(info[1].textContent);
                let decFactor = Number(info[2].textContent);
                bought.push({
                         name: name,
                         price : price,
                        decFactor : decFactor
                });
            }
        }
        let output = '';
            let outputTextBox = document.getElementsByTagName('textarea')[1];
        output = `Bought furniture: ${bought.map(e => e.name).join(", ")}`;
        output += `\nTotal price: ${bought.reduce((total, current) => total + current.price, 0).toFixed(2)}`;
        output += `\nAverage decoration factor: ${bought.reduce((total, current) => total + current.decFactor, 0) / bought.length}`;
         outputTextBox.value = output;
    })
}