function colorize() {
    const rows = document.querySelectorAll('tr');

    for(i = 0; i < rows.length; i++){
        if(i % 2 != 0){
            rows[i].style.backgroundColor = 'teal'
        };
    };
}