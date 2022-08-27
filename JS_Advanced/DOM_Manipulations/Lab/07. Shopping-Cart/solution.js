function solve() {
   class Product {
      constructor(title, price) {
         this.title = title;
         this.price = price;
      }
   }

   const productDivs = Array.from(document.querySelectorAll('.product'));
   const textArea = document.querySelector('textarea');
   const checkOutBtn = document.querySelector('.checkout');

   const cart = [];

   productDivs.forEach(x => x.addEventListener('click', addProduct));
   checkOutBtn.addEventListener('click', checkOut);

   function addProduct(e) {
      if (e.target.localName === 'button') {
         const title = e.currentTarget.querySelector('.product-title').textContent;
         const price = Number(e.currentTarget.querySelector('.product-line-price').textContent);

         textArea.textContent += `Added ${title} for ${price.toFixed(2)} to the cart.\n`;

         let product = cart.find(x => x.title === title);

         if (product === undefined) {
            product = new Product(title, price);
            cart.push(product);
            return;
         }

         product.price += price;
      }
   }

   function checkOut(e){
      const totalPrice = cart.reduce((acc,product) => acc + product.price, 0);
      const allProductTitles = cart.map(x => x.title).join(', ');

      textArea.textContent += `You bought ${allProductTitles} for ${totalPrice.toFixed(2)}.`;

      const allBtns = Array.from(document.querySelectorAll('button'));
      allBtns.forEach(x => x.setAttribute('disabled', true));
   }
}