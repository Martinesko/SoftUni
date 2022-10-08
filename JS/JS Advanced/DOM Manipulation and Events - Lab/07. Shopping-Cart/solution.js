function solve() {
    let products = document.getElementsByClassName('product');
    let textarea = document.getElementsByTagName('textarea')[0];
    textarea.value = ``;
    let shoppingCart = [];
    for (const product of products) {
        let button = product.getElementsByClassName('product-add')[0];
        button.addEventListener('click',function () {
            let textarea = document.getElementsByTagName('textarea')[0];
            shoppingCart.push(product);
            let name = product.getElementsByClassName('product-title')[0].textContent;
            let price = Number(product.getElementsByClassName('product-line-price')[0].textContent);
            textarea.value += `Added ${name} for ${price} to the cart.\n`;
        });
    };
    let CheckoutButton = document.getElementsByTagName('button')[3];
    CheckoutButton.addEventListener('click',function (){
        let textarea = document.getElementsByTagName('textarea')[0];
        let sum = 0;
        let names = [];

        for (const product of shoppingCart) {
            sum += Number(product.getElementsByClassName('product-line-price')[0].textContent);
            if (!names.includes(product.getElementsByClassName('product-title')[0].textContent)) {
                names.push(product.getElementsByClassName('product-title')[0].textContent);
            }
        }
        textarea.value += `You bought ${names.join(", ")} for ${sum.toFixed(2)}.`;
    });
}