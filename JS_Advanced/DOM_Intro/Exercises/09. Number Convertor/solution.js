function solve() {
    document.querySelector('#container button').addEventListener('click', onClick);

    const selectMenuTo = document.getElementById('selectMenuTo');  

    const binaryOpt = document.createElement('option');
    const hexadecimalOpt = document.createElement('option');

    binaryOpt.value = 'binary';
    hexadecimalOpt.value = 'hexadecimal';

    binaryOpt.innerText = 'Binary';
    hexadecimalOpt.innerText = 'Hexadecimal';

    selectMenuTo.appendChild(binaryOpt);
    selectMenuTo.appendChild(hexadecimalOpt);

    function onClick() {
        const number = Number(document.getElementById('input').value);
        const resultInput = document.getElementById('result');

        if (selectMenuTo.value == 'binary') {
            resultInput.value = number.toString(2);
        }
        else if (selectMenuTo.value == 'hexadecimal') {
            resultInput.value = number.toString(16).toUpperCase();
        }
    }
}