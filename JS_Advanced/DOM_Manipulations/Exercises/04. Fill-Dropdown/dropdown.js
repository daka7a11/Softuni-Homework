function addItem() {
    const textInput = document.getElementById('newItemText');
    const valueInput = document.getElementById('newItemValue');

    const select = document.getElementById('menu');

    const newOption = document.createElement('option');
    newOption.textContent = textInput.value;
    newOption.value = valueInput.value;

    select.appendChild(newOption);
    
    textInput.value = '';
    valueInput.value = '';
}