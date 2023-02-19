import { login } from "./auth.js";

const loginEl = document.querySelector("#login");
const form = loginEl.querySelector("form");

export function renderLogin() {
  loginEl.style.display = "block";
}

form.addEventListener("submit", (ev) => {
  ev.preventDefault();
  const formData = new FormData(ev.target);
  login(
    [...formData.entries()].reduce(
      (p, [k, v]) => Object.assign(p, { [k]: v }),
      {}
    )
  );
});
