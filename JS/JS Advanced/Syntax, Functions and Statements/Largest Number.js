function largestNumber(first,second,third) {
    let result;
    if (first > second && first > third) {
        result = first;
    }
    if (second>first & second > third){
        result = second;
    }
    if (third>first && third>second){
        result = third
    }
    console.log(`The largest number is ${result}.`)
}
largestNumber(-3, -5 ,-22.5)
