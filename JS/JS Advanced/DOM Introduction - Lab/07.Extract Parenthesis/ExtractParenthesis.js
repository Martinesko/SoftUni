function extract(content) {
    let paragraph = document.getElementById(content).textContent;
let patern = /\(([^)]+)\)/g;
let result = [];

let match = patern.exec(paragraph);
while(match){
    result.push(match[1]);
    match = patern.exec(paragraph);
}
return result.join('; ');
}