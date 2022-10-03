function encodeAndDecodeMessages() {
    let inputTextArea = document.querySelector('textarea');
    let ButtonOne = document.querySelector('button');

    let outputTextArea = document.querySelectorAll('textarea')[1];
    let ButtonTwo = document.querySelectorAll('button')[1];
    ButtonOne.addEventListener('click', function (){
        let startingText = inputTextArea.value;
        let outputText = '';
        for (let i = 0; i < startingText.length; i++) {
            let encodedLetter = String.fromCharCode(startingText.charCodeAt(i) + 1);
            outputText += encodedLetter;
        }
        inputTextArea.value = '';
        outputTextArea.value = outputText;
    });
    ButtonTwo.addEventListener('click', function (){
        let startingText = outputTextArea.value;
        let outputText = '';
        for (let i = 0; i < startingText.length; i++) {
            let encodedLetter = String.fromCharCode(startingText.charCodeAt(i) - 1);
            outputText += encodedLetter;
        }
        inputTextArea.value = outputText;
    });
}