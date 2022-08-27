function attachGradientEvents() {
    const divResult = document.getElementById('result');
    const hoverDiv = document.getElementById('gradient');
    hoverDiv.addEventListener('mousemove', gradient);
    hoverDiv.addEventListener('mouseout', mouseOut);

    function gradient(e){
        let position = e.offsetX / (e.target.clientWidth - 1);
        let percentage = Math.trunc(position * 100);
        divResult.textContent = `${percentage}%`;
    }

    function mouseOut(e){
        divResult.textContent = '';
    }
}