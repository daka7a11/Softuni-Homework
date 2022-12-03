function attachEventsListeners() {
    const main = document.querySelector('main');

    main.addEventListener('click', onClick);

    function onClick(e){
        if(e.target.type === 'button'){
            const input = e.target.parentElement.querySelector('input[type="text"]');
            
            let inputsToConvert = Array.from(document.querySelectorAll('main div input[type="text"]'));

            const inputValue = input.value;
            const inputId = input.id;

            if(inputId === 'days'){
                inputsToConvert = filterDivsToConvert(inputsToConvert,'days');

                inputsToConvert[0].value = inputValue * 24; // hours
                inputsToConvert[1].value = inputValue * 24 * 60; // minutes
                inputsToConvert[2].value = inputValue * 24 * 60 * 60; // seconds
            }
            else if(inputId === 'hours'){
                inputsToConvert = filterDivsToConvert(inputsToConvert,'hours');

                inputsToConvert[0].value = inputValue / 24; // days
                inputsToConvert[1].value = inputValue * 60; // minutes
                inputsToConvert[2].value = inputValue * 60 * 60; //seconds
            }
            else if(inputId === 'minutes'){
                inputsToConvert = filterDivsToConvert(inputsToConvert,'minutes');

                inputsToConvert[0].value = inputValue / 60 / 24; // days
                inputsToConvert[1].value = inputValue / 60; // hours
                inputsToConvert[2].value = inputValue * 60; //seconds
            }
            else if(inputId === 'seconds'){
                inputsToConvert = filterDivsToConvert(inputsToConvert,'seconds');

                inputsToConvert[0].value = inputValue / 60 /60 / 24; // days
                inputsToConvert[1].value = inputValue / 60 /60; // hours
                inputsToConvert[2].value = inputValue / 60; // minutes
            }
        }
    }

    function filterDivsToConvert(inputsToConvert,filter){
        return inputsToConvert.filter(x => x.id != filter);
    }
}