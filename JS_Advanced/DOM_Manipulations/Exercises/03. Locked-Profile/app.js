function lockedProfile() {
    const profileDivs = Array.from(document.querySelectorAll('div .profile'));

    profileDivs.forEach(x => x.addEventListener('click', onClick));

    function onClick(e){
        if(e.target.localName === 'button'){
            const currTarget = e.currentTarget;
            const hiddenDiv = currTarget.querySelector('div');
            const button = currTarget.querySelector('button');

            const checkedInput = currTarget.querySelector('input[type="radio"]:checked');
            
            if(checkedInput.defaultValue === 'lock'){return;}

            if(hiddenDiv.style.display == ''){
                hiddenDiv.style.display = 'inline-block';
                button.textContent = 'Hide it';
            }
            else{
                hiddenDiv.style.display = '';
                button.textContent = 'Show more';
            }
        }
    }
}