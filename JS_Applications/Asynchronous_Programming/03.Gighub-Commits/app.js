const commitsEl = document.querySelector("#commits");
const usernameEl = document.querySelector("#username");
const repoEl = document.querySelector("#repo");

function getUrl(username, repository) {
  return `https://api.github.com/repos/${username}/${repository}/commits`;
}

function loadCommits() {
  commitsEl.innerHTML = "";
  fetch(getUrl(usernameEl.value, repoEl.value))
    .then((res) => {
      if (res.ok) {
        return res.json();
      }

      return Promise.reject(res);
    })
    .then((data) => {
      //"<commit.author.name>: <commit.message>"
      data.forEach((x) => {
        const li = document.createElement("li");
        li.textContent = `${x.commit.author.name}: ${x.commit.message}`;
        commitsEl.appendChild(li);
      });
    })
    .catch((err) => {
      const li = document.createElement("li");
      console.log(err);
      li.textContent = `Error: ${err.status} (Not Found)`;
      commitsEl.appendChild(li);
    });
}
