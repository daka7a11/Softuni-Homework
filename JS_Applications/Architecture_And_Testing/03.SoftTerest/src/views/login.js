import { login } from "../api.js";

const loginEl = document.querySelector(".loginPage");
const formEl = loginEl.querySelector("form");
formEl.addEventListener("submit", submit);

let context = null;

export function renderLogin(inputContext) {
  context = inputContext;
  context.showView(loginEl);
}

async function submit(e) {
  e.preventDefault();
  const formData = new FormData(formEl);

  const email = formData.get("email");
  const password = formData.get("password");

  const data = await login({ email, password });
  sessionStorage.setItem("user", JSON.stringify(data));
  alert(`You logged as ${data.email}`);

  formEl.reset();
  context.goto("/");
}
