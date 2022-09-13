 function sameNumbers(number) {
     let sum = 0;
     let numberToString = number.toString();
     let isRight = true;
     for (let i = 0; i < numberToString.length; i++) {
         sum += Number(numberToString[i])
         let symbol = numberToString[0]
         if (symbol !== numberToString[i]) {
             isRight = false;
         }
     }
     console.log(isRight);
     console.log(sum);
 }
 sameNumbers(1234)