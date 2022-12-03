window.addEventListener("load", solve);

function solve() {
  const inputs = document.querySelectorAll('.form-wrapper form fieldset input');
  const inputMake = inputs[0];
  const inputModel = inputs[1];
  const inputYear = inputs[2];
  const inputOriginalCost = inputs[3];
  const inputSellingPrice = inputs[4];
  const selectFuel = document.getElementById('fuel');
  
  const tbody = document.getElementById('table-body');
  

  const submitButtonEl = document
    .getElementById("publish")
    .addEventListener("click", publish);

    function publish(ev) {
      ev.preventDefault();

      if(!isInputFieldsValid()){
        return;
      }
    
      const tr = elGenerator('tr');
      tr.setAttribute('class', 'row');
      const tdMake = elGenerator('td', inputMake.value, tr);
      const tdModel = elGenerator('td', inputModel.value, tr);
      const tdYear = elGenerator('td', inputYear.value, tr);
      const tdFuel = elGenerator('td', selectFuel.value, tr);
      const tdPrice = elGenerator('td', inputOriginalCost.value, tr);
      const tdNewPrice = elGenerator('td', inputSellingPrice.value, tr);
      const tdBtns = elGenerator('td', '', tr);
      const editBtn = elGenerator('button', 'Edit', tdBtns);
      editBtn.setAttribute('class', 'action-btn edit');
      const sellBtn = elGenerator('button', 'Sell', tdBtns);
      sellBtn.setAttribute('class', 'action-btn sell')
    
      tbody.appendChild(tr);
    
      editBtn.addEventListener('click', edit);
      sellBtn.addEventListener('click', sell);
    
      clearInputFields();
    }
    
    function edit(e) {
      const tr = e.target.parentElement.parentElement;
      const tds = tr.querySelectorAll('td');
      const make = tds[0].textContent;
      const model = tds[1].textContent;
      const year = tds[2].textContent;
      const fuel = tds[3].textContent;
      const price = tds[4].textContent;
      const newPrice = tds[5].textContent;
    
      inputMake.value = make;
      inputModel.value = model;
      inputYear.value = year;
      selectFuel.value = fuel;
      inputOriginalCost.value = price;
      inputSellingPrice.value = newPrice
    
      tr.remove();
    }
    
    function sell(e) {
      const tr = e.target.parentElement.parentElement;
      const tds = tr.querySelectorAll('td');
      const make = tds[0].textContent;
      const model = tds[1].textContent;
      const year = tds[2].textContent;
      const fuel = tds[3].textContent;
      const price = tds[4].textContent;
      const newPrice = tds[5].textContent;
    
      tr.remove();
    
      const ul = document.getElementById('cars-list');
      const li = elGenerator('li','',ul);
      li.setAttribute('class','each-list');
      const spanMakeAndModel = elGenerator('span',`${make} ${model}`, li);
      const spanProcutionYear = elGenerator('span',`${year}`, li);
      const spanProfitMade = elGenerator('span',`${newPrice - price}`, li);
    
      changeTotalProfit();
    }
    
    function changeTotalProfit(){
      const lis = document.querySelectorAll('#cars-list li');
    
      let totalProfit = 0;
      lis.forEach(li => {
        totalProfit += Number(li.children[2].textContent);
      });
    
      document.getElementById('profit').textContent = totalProfit.toFixed(2);
    }
    
    function clearInputFields(){
      inputMake.value = '';
      inputModel.value = '';
      inputYear.value = '';
      selectFuel.value = '';
      inputOriginalCost.value = '';
      inputSellingPrice.value = '';
    }

    function isInputFieldsValid(){
      if(!inputMake.value){
        return false;
      }
      if(!inputModel.value){
        return false;
      }
      if(!inputYear.value){
        return false;
      }
      if(!selectFuel.value){
        return false;
      }
      if(!inputOriginalCost.value){
        return false;
      }
      if(!inputSellingPrice.value){
        return false;
      }
      if(inputSellingPrice.value < inputOriginalCost.value){
        return false;
      }

      return true;
    }
    
    function elGenerator(type, content, parent) {
      const element = document.createElement(type);
      element.textContent = content;
    
      if (parent) {
        parent.appendChild(element);
      }
      return element;
    }
}