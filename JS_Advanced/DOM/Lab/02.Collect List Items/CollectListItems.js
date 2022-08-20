function extractText() {
    const listItems = document.querySelectorAll('li');
    const textArea = document.getElementById('result');

    for (i = 0; i < listItems.length; i++) {
        const currLiText = listItems[i].outerText;
        textArea.value += currLiText;
    }
}