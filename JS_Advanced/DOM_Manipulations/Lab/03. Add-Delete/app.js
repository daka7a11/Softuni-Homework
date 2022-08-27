function addItem() {
    let ul = document.getElementById('items');
    const inputText = document.getElementById('newItemText');

    const newLi = document.createElement('li');

    const a = document.createElement('a');
    a.textContent = '[Delete]';
    a.href = '#';

    newLi.textContent = inputText.value;
    newLi.appendChild(a);

    a.addEventListener('click', function(e){
        e.preventDefault();
        e.target.parentElement.remove();
    });

    ul.appendChild(newLi);

    inputText.value = '';
}