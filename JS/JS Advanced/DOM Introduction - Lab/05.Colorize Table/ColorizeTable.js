function colorize() {
    let lines = document.querySelectorAll('table tr');
    let index = 0;
    for (let line of lines) {
        index++;
        if (index % 2 == 0) {
            line.style.background = 'teal';
        }
    }
}