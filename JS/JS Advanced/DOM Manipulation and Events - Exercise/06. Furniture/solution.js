function solve() {
    let button = document.getElementsByTagName('button')[0];
    let list = document.querySelector('tbody');
    button.addEventListener('click' , function () {
        let products = JSON.parse(document.getElementsByTagName('textarea')[0].value);
        for (const product of products) {
            let tr = document.createElement('tr');
            tr.innerHTML = `<td><img src="${product.img}"> </td> <td> <p>${product.name}</p></td><td><p>${product.price}</p></td><td><p>${product.decFactor}
              </p></td><td><input type="checkbox"/> </td>`;
            list.appendChild(tr);
            document.getElementsByTagName('textarea')[0].value = '';
        }
    })

    let sellButton = document.getElementsByTagName('button')[1];
    sellButton.addEventListener('click',function () {
        let outputTextBox = document.getElementsByTagName('textarea')[1];
        let bought = [];
        for (const product of Array.from(list.children)) {
            if (product.getElementsByTagName("input")[0].checked == true){
                bought.push(product);
            }
        }
            outputTextBox.value = `{Bought furniture: ${bought.map(e => e.name(", "))}`;
            outputTextBox.value = `\nTotal price ${Bought.reduce((total, current) => total + current.price, 0).toFixed(2)}`;
            outputTextBox.value = `\nAverage decoration factor: ${Bought.reduce((total, current) => total + current.decFactor, 0) / Bought.length}`;
    })
}