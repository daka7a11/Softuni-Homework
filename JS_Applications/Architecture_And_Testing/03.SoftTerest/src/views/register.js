import { register as apiReg } from "../api.js";

const registerEl = document.querySelector(".registerPage");
const formEl = registerEl.querySelector("form");
formEl.addEventListener("submit", register);

let context = null;

export function renderRegister(inputContext) {
  context = inputContext;
  context.showView(registerEl);
}

async function register(e) {
  e.preventDefault();

  const formData = new FormData(formEl);
  const email = formData.get("email");
  const password = formData.get("password");
  const repPassword = formData.get("repeatPassword");

  if (password != repPassword) {
    alert("The passwords do not match.");
    return;
  }

  const user = await apiReg({ email, password });
  sessionStorage.setItem("user", JSON.stringify(user));
  alert(`You logged as ${user.email}`);

  formEl.reset();
  context.goto("/");
}
