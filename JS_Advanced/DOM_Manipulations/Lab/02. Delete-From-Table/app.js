function deleteByEmail() {
    const inputEmail = document.querySelector('label input');

    const divResult = document.getElementById('result');

    const emailTds = Array.from(document.querySelectorAll('table tbody td:last-child'));

    const tdToDelete = emailTds.find(x => x.textContent === inputEmail.value);

    if(tdToDelete === undefined){
        divResult.textContent = 'Not found.';
        return;
    }

    tdToDelete.parentElement.remove();
    divResult.textContent = 'Deleted.';
}