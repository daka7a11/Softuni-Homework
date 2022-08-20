function solve() {
  const text = document.getElementById('text').value;
  const convention = document.getElementById('naming-convention').value;
  const resultSpan = document.getElementById('result');

  let resultText = '';

  const words = text.toLowerCase().split(' ');

  function wordsToConvection(firstWordIndex){
    for (let i = firstWordIndex; i < words.length; i++) {
      const currWord = words[i];
      resultText += currWord[0].toUpperCase() + currWord.slice(1);
    }
  }

  if (convention == 'Camel Case') {
    resultText += words[0];
    wordsToConvection(1);
  }
  else if(convention == 'Pascal Case'){
    wordsToConvection(0);
  }
  else{
    resultText = 'Error!';
  }

  resultSpan.innerText = resultText;
}