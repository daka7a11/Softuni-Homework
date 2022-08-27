function solve() {
  const inputSpan = document.getElementById('input');
  const sentences = inputSpan.value.split('.').map(x => x.trim()).filter(x => x !== "");
  const outputDiv = document.getElementById('output');

  let pText = "";
  for(let i = 0; i<sentences.length; i++){
    if(i % 3 == 0 && pText.length > 0){
      outputDiv.innerHTML += `<p>${pText}</p>`;
      pText = "";
    }

    pText.length == 0 
    ? pText += sentences[i] + '.'
    : pText += ` ${sentences[i]}.`;
  }

  pText.length > 0 ? outputDiv.innerHTML += `<p>${pText}</p>` : "";
}