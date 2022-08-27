function sumTable() {
    let result = 0;
    const tr = document.querySelectorAll('tr');
    const trSum = document.getElementById('sum');
    for (let i = 0; i < tr.length; i++) {
        const tds = tr[i].querySelectorAll('td');

        if (tds.length == 0) continue;

        const price = Number(tds[1].innerText);
        result += price;
    };

    trSum.innerText = result;
}