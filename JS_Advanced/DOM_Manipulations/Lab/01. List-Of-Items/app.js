function addItem() {
    const ul = document.getElementById('items');
    const inputText = document.getElementById('newItemText').value;

    const newLiItem = document.createElement('li');
    newLiItem.textContent = inputText;

    ul.appendChild(newLiItem);
}