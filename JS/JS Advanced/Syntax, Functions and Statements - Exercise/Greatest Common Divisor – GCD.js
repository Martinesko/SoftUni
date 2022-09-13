function greatestCommonDivisorGCD(first , second) {
    for (let i = 2; i < 1000000000000; i++) {
        if (first%i === 0 && second%i === 0){
                console.log(i);
                break;
        }
    }
}
greatestCommonDivisorGCD(2154, 458)