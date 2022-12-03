function solve() {
  class Furniture {
    constructor(name, img, price, decFactor) {
      this.name = name;
      this.img = img;
      this.price = price;
      this.decFactor = decFactor;
    }
  }
  const inputTextArea = document.querySelector('#exercise textarea');
  const generateBtn = document.querySelector('#exercise button');
  const buyBtn = document.querySelector('#exercise button:last-child');
  const tableBody = document.querySelector('.table tbody');

  generateBtn.addEventListener('click', generate);
  buyBtn.addEventListener('click', buy);

  function generate(e) {
    const inputFurnitures = JSON.parse(inputTextArea.value);

    inputFurnitures.forEach(furniture => {
      const newTr = document.createElement('tr');
      const tdForImg = document.createElement('td');
      const tdForName = document.createElement('td');
      const tdForPrice = document.createElement('td');
      const tdForDecFactor = document.createElement('td');
      const tdForCheckBox = document.createElement('td');

      const img = document.createElement('img');
      img.src = furniture.img;
      tdForImg.appendChild(img);

      const pForName = document.createElement('p');
      pForName.textContent = furniture.name;
      tdForName.appendChild(pForName);

      const pForPrice = document.createElement('p');
      pForPrice.textContent = furniture.price;
      tdForPrice.appendChild(pForPrice);

      const pForDecFactor = document.createElement('p');
      pForDecFactor.textContent = furniture.decFactor;
      tdForDecFactor.appendChild(pForDecFactor);

      const inputForCheckBox = document.createElement('input');
      inputForCheckBox.type = 'checkbox';
      tdForCheckBox.appendChild(inputForCheckBox);

      newTr.appendChild(tdForImg);
      newTr.appendChild(tdForName);
      newTr.appendChild(tdForPrice);
      newTr.appendChild(tdForDecFactor);
      newTr.appendChild(tdForCheckBox);

      tableBody.appendChild(newTr);
    });
  }

  function buy(e) {
    const checkBoxes = document.querySelectorAll('input:checked');

    const boughtFurnitures = [];
    checkBoxes.forEach(x => {
        const checkedTr = x.parentElement.parentElement;

        const img = checkedTr.children[0].children[0].src;
        const name = checkedTr.children[1].children[0].textContent;
        const price = Number(checkedTr.children[2].children[0].textContent);
        const decFactor = Number(checkedTr.children[3].children[0].textContent);

        const boughtFurniture = new Furniture(name, img, price, decFactor);
        boughtFurnitures.push(boughtFurniture);
    });

    if(boughtFurnitures.length === 0){ return;}

    const boughtFurnitureNames = boughtFurnitures.map(x => x.name).join(', ');
    const totalPrice = boughtFurnitures.map(x => x.price)
      .reduce((acc, currPrice) => acc + currPrice, 0);
    const avgDecFactor = (boughtFurnitures.map(x => x.decFactor)
      .reduce((acc, currVal) => acc + currVal, 0)) / boughtFurnitures.length;

    const resultTextArea = document.querySelectorAll('#exercise textarea')[1];
    resultTextArea.value += `Bought furniture: ${boughtFurnitureNames}\n`;
    resultTextArea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    resultTextArea.value += `Average decoration factor: ${avgDecFactor}`;
  }
}