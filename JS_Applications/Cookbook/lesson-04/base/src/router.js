import { renderHome } from "./catalog.js";
import { renderLogin } from "./login.js";
import { renderRegister } from "./register.js";
import { renderCreate } from "./create.js";
// import { notFound } from "./notFound.js";
import { updateNavigation, logout } from "./auth.js";
import {} from "./edit.js";

const routes = {
  "/": renderHome,
  login: renderLogin,
  register: renderRegister,
  create: renderCreate,
  logout: logout,
};

export function router(path) {
  hideAllSections();

  const renderer = routes[path];
  renderer();
  updateNavigation();
}

function hideAllSections() {
  const sections = document.querySelectorAll("section");
  sections.forEach((x) => (x.style.display = "none"));
}
