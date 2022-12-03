function create(words) {
   const contentDiv = document.getElementById('content');
   words.forEach(word => {
      const div = document.createElement('div');
      const p = document.createElement('p');

      p.textContent = word;
      p.style.display = 'none';

      div.appendChild(p);

      div.addEventListener('click', function(e){
         p.style.display = '';
      })

      contentDiv.appendChild(div);
   });
}