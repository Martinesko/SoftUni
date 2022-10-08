function focused() {
   let maindiv = document.getElementsByTagName('div')[0];
   Array.from(maindiv.getElementsByTagName("input")).forEach(element => {
       element.addEventListener("focus", function(e){
         e.target.parentNode.classList.add("focused");

         e.target.addEventListener('blur',function (){
          e.target.parentNode.classList.remove("focused");
         })
      });
   });
}