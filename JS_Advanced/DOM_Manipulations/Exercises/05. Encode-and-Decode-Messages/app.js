function encodeAndDecodeMessages() {
    const contentDivs = document.querySelectorAll('main div');
    const senderDiv = contentDivs[0];
    const receiverDiv = contentDivs[1];

    const senderTextArea = senderDiv.querySelector('textarea');
    const senderButton = senderDiv.querySelector('button');

    const receiverTextArea = receiverDiv.querySelector('textarea');
    const receiverButton = receiverDiv.querySelector('button');

    senderButton.addEventListener('click', encodeAndSend);
    receiverButton.addEventListener('click', decodeAndRead);

    function encodeAndSend(e) {
        const text = senderTextArea.value;
        let encodedText = '';

        encodedText = changeTextCharCode(text, 1);

        receiverTextArea.value = encodedText;

        senderTextArea.value = '';
    }

    function decodeAndRead(e) {
        const text = receiverTextArea.value;

        const decodedText = changeTextCharCode(text, -1);

        receiverTextArea.value = decodedText;
    }

    function changeTextCharCode(text, valueToAdd){
        let result = '';
        for (let i = 0; i < text.length; i++) {
            const currChar = text[i];
            result += String.fromCharCode(currChar.charCodeAt(0) + valueToAdd);
        }
        return result;
    }
}