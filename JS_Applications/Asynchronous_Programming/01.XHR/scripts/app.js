const resultEl = document.querySelector("#res");
const url = "https://api.github.com/users/testnakov/repos";

function loadRepos() {
  const xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
      resultEl.textContent = xhttp.responseText;
    }
  };
  xhttp.open("GET", url);
  xhttp.send();
}
