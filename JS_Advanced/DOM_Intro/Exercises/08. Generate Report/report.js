function generateReport() {
    class Column {
        constructor(name, value) {
            this.name = name;
            this.value = value;
        }
    }

    class ReportObject{
        constructor(name, value){
            this.name = name;
            this.value = value;
        }
    }

    const headThs = document.querySelectorAll('thead tr th');
    const outputTextArea = document.getElementById('output');

    const colsToReport = [];
    for (let i = 0; i < headThs.length; i++) {
        const currTh = headThs[i];

        if (currTh.children[0].checked) {
            const colName = currTh.innerText.trim();

            colsToReport.push(new Column(colName, i));
        }
    }

    const bodyTrs = document.querySelectorAll('tbody tr');

    const objectsToReport = [];

    for (let i = 0; i < bodyTrs.length; i++) {
        const currRowDates = bodyTrs[i].children;

        const objectToReport = {};

        for (let j = 0; j < colsToReport.length; j++) {
            const currColToReport = colsToReport[j];
            const currRowColValue =  currRowDates[currColToReport.value].innerText;
        
            objectToReport[currColToReport.name.toLowerCase()] = currRowColValue;
            ;
        }

        objectsToReport.push(objectToReport);
    }

    const json = JSON.stringify(objectsToReport);

    outputTextArea.innerHTML = json;
}