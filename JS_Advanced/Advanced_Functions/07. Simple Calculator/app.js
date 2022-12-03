function calculator() {

    let inputNum1;
    let inputNum2;
    let inputResult;

    let result;

    function init(selector1, selector2, resultSelector) {
        inputNum1 = document.querySelector(selector1);
        inputNum2 = document.querySelector(selector2);
        inputResult = document.querySelector(resultSelector);
    }
    function add() {
        result = inputNum1.value + inputNum2.value;
        showResult();
    }
    function subtract() {
        result = inputNum1.value - inputNum2.value;
        showResult();
    }

    function showResult(){
        inputResult.value = result;
    }

    const calc = {
        init,
        add,
        subtract,
    }

    return calc;
}