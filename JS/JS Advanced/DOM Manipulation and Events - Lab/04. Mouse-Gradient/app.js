    function attachGradientEvents() {
      let grad = document.getElementById('gradient');
      let result = document.getElementById('result');

      grad.addEventListener('mousemove',  (e) =>{
    let maxWidth = e.target.clientWidth;
    let pointerpostionx = e.offsetX;
    let percentage = Math.floor((pointerpostionx / maxWidth)*100);
    result.textContent = `${percentage}%`;
      }
    )
    }