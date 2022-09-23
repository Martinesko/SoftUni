function calc() {
    let firstNumber = Number(document.getElementById("num1").value);
    let secondNumber = Number(document.getElementById("num2").value);
    let Sum = firstNumber + secondNumber;
    let output = document.querySelector("#sum");
    output.value = Sum;
}
