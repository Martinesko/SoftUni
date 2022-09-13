function sumlenght(first,second,third) {

    let firstlenght = first.length;
    let secondlenght = second.length;
    let thirdlenght = third.length;
    let sum = firstlenght+secondlenght+thirdlenght;
    let avarageLenght = sum / 3;
    console.log(sum)
    console.log (Math.floor(avarageLenght))
}
sumlenght('chocolate', 'ice cream', 'cake')