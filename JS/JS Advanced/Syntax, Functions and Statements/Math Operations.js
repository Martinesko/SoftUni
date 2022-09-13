function MathOperations(first , second , operation){
    if (operation === '+'){
        console.log(first+second)
    }
    if (operation === '-'){
        console.log(first-second)
    }
    if (operation === '*'){
        console.log(first*second)
    }
    if (operation === '/'){
        console.log(first/second)
    }
    if(operation === '%') {
        console.log(first%second)
    }
    if(operation === '**'){
        console.log(first**second)
    }
}
MathOperations(3, 5.5, '*')