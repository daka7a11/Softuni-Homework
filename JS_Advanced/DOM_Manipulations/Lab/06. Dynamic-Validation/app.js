function validate() {
    const regexEmail = /^[a-z\.a-z]+@[a-z]+\.[a-z]{2,4}$/;

    const input = document.getElementById('email');

    input.addEventListener('change', function(e){
        if(input.value.match(regexEmail)){
            input.classList.remove('error');
            return;
        }
        input.classList.add('error');
    });
}