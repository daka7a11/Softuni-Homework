function focused() {
    const inputFields = Array.from(document.querySelectorAll('div input'));

    inputFields.forEach(x => x.addEventListener('focus', function(e){
        e.target.parentElement.classList.add('focused');
    }));

    inputFields.forEach(x => x.addEventListener('blur', function(e){
        e.target.parentElement.classList.remove('focused');
    }));
}