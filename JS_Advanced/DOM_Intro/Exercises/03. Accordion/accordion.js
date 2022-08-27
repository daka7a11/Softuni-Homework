function toggle() {
    const button = document.querySelector('.head .button');
    const textDiv = document.getElementById('extra');

    if(button.innerText.toLowerCase() == 'more'){
        button.innerText = 'Less';
        textDiv.style.display = 'block';
    }
    else{
        button.innerText = 'More';
        textDiv.style.display = 'none';
    }
}
