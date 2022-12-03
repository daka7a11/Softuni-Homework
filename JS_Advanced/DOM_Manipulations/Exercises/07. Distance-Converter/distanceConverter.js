function attachEventsListeners() {
    const ratesFromMeter = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254,
    }

    const convertBtn = document.getElementById('convert');
    convertBtn.addEventListener('click', convert);

    function convert(e) {
        const inputValueFrom = document.getElementById('inputDistance');
        const fromSelect = document.getElementById('inputUnits');
        const inputTo = document.getElementById('outputDistance');
        const selectOutput = document.getElementById('outputUnits');

        const inputValueInMeters = Number(inputValueFrom.value) * ratesFromMeter[fromSelect.value];
        const outputValue = inputValueInMeters / ratesFromMeter[selectOutput.value];

        inputTo.value = outputValue;
    };
}