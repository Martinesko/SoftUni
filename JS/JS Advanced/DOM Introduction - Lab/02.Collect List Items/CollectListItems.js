function extractText() {
   let sta = document.querySelectorAll("ul#items li");
   let textarea = document.querySelector("#result");
   for (let textareaElement of sta) {
      textarea.value += textareaElement.textContent + "\n";
   }
}