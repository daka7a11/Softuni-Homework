function search() {
   let matches = 0;

   const townsLi = document.getElementById('towns').children;
   const searchText = document.getElementById('searchText').value;
   const divResult = document.getElementById('result');

   for (i = 0; i < townsLi.length; i++) {
      const townLi = townsLi[i];
      if(townLi.innerText.includes(searchText)){
         townLi.style.fontWeight = 'bold';
         townLi.style.textDecoration = 'underline';
         matches++;
      }
   }

   divResult.innerText = `${matches} matches found`;
}
