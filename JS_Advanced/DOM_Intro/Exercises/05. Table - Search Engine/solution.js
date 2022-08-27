function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const bodyTrs = document.getElementsByClassName('container')[0].children[2].children;
      const inputSearch = document.getElementById('searchField');
      const searchText = inputSearch.value

      //searctText != "" !!!
      
      for (let i = 0; i < bodyTrs.length; i++) {
         const currTr = bodyTrs[i];
         currTr.classList.contains('select') ? currTr.classList.remove('select') : false ;
         for(let j = 0; j<currTr.childElementCount; j++){
            const tdText = currTr.children[j].innerText;

            if(tdText.includes(searchText)){
               //Call func to change tr color
               currTr.classList.add('select');
               break;
            }
         }
      }

      inputSearch.value = '';
   }
}