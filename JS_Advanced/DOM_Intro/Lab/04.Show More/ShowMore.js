// function showText() {
//     const hiddenSpanText = document.getElementById('text').innerText;
//     const textToReplace = document.getElementById('more').innerText;

//     document.body.innerText = document.body.innerText.replace(textToReplace, hiddenSpanText);
// }

function showText() {
    document.getElementById('more').remove();
    document.getElementById('text').style.display = 'inline';
}