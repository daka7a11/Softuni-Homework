const url = "http://localhost:3030/users/login";
const homeHref = "/Data_And_Authentication/05.Fisher-Game/index.html";

const mainEl = document.querySelector("main");
const loginViewEl = document.getElementById("login-view");

const form = loginViewEl.querySelector("form");
const loginBtn = document.getElementById("login");
const logoutBtn = document.getElementById("logout");

form.addEventListener("submit", login);
loginBtn.addEventListener("click", renderLoginPage);
logoutBtn.addEventListener("click", logout);

export function renderLoginPage(e) {
  e.preventDefault();

  mainEl.innerHTML = "";
  mainEl.appendChild(loginViewEl);
}

export function login(e) {
  e.preventDefault();
  const formData = new FormData(form);
  const email = formData.get("email");
  const password = formData.get("password");

  if (!(email && password)) {
    alert("Invalid email or password");
    return;
  }

  fetch(url, {
    method: "POST",
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify({ email, password }),
  })
    .then((res) => res.json())
    .then((data) => {
      sessionStorage.setItem("accessToken", data.accessToken);
      sessionStorage.setItem("email", data.email);
      sessionStorage.setItem("username", data.username);
      sessionStorage.setItem("ownerId", data._id);

      alert("Successfuly logged as " + data.email);
      location.href = homeHref;
    });
}

export function logout(e) {
  e.preventDefault();

  mainEl.innerHTML = "";

  sessionStorage.clear();

  location.href = homeHref;
}
