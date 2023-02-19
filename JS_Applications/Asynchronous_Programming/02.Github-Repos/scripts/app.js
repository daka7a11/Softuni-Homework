const usernameEl = document.querySelector("#username");
const reposEl = document.querySelector("#repos");
function getUrl(username) {
  return `https://api.github.com/users/${username}/repos`;
}
function loadRepos() {
  reposEl.innerHTML = "";
  fetch(getUrl(usernameEl.value))
    .then((res) => res.json())
    .then((data) => {
      console.log(data);

      data.forEach((x) => {
        const li = document.createElement("li");
        const a = document.createElement("a");
        a.textContent = `${x.full_name}`;
        a.href = x.html_url;
        li.appendChild(a);
        reposEl.append(li);
      });
    })
    .catch((err) => {
      const li = document.createElement("li");
      li.textContent = "Not Found";
      reposEl.append(li);
    });
}
