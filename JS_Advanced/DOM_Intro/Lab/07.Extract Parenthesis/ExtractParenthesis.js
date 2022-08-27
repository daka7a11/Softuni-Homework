function extract(content) {
    const text = document.getElementById(content).innerText;

    let flagForRecordWord = false;
    let wordToAdd = "";
    let words = [];

    for (let i = 0; i < text.length; i++) {
        const currChar = text[i];
        if(currChar == "("){
            flagForRecordWord = true;
            continue;
        }
        else if(currChar == ")"){
            flagForRecordWord = false;
            words.push(wordToAdd);
            wordToAdd = "";
            continue;
        }

        if(flagForRecordWord){
            wordToAdd += currChar;
        }
    }

    return words.join("; ");
}