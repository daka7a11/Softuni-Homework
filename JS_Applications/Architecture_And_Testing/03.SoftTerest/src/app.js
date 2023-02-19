import { init } from "./router.js";
import { renderHome } from "./views/home.js";
import { renderLogin } from "./views/login.js";
import { renderRegister } from "./views/register.js";
import { renderIdeas } from "./views/ideas.js";
import { renderCreate } from "./views/create.js";
import { logout as apiLogout } from "./api.js";
import { renderDetails } from "./views/details.js";

const mainEl = document.querySelector(".content");
const views = document.querySelector(".views");
views.replaceChildren();

const navigation = document.querySelector("nav");
const userEls = navigation.querySelectorAll(".user");
const guestEls = navigation.querySelectorAll(".guest");
navigation.addEventListener("click", navHandler);

const context = { showView, updateNav, goto };
const links = {
  "/": renderHome,
  "/register": renderRegister,
  "/login": renderLogin,
  "/ideas": renderIdeas,
  "/create": renderCreate,
  "/logout": logout,
  "/details": renderDetails,
};

const router = init(context, links);

await router.render("/");

async function navHandler(e) {
  e.preventDefault();

  let target = e.target;

  if (target.tagName === "IMG") {
    target = target.parentElement;
  }

  if (target.tagName === "A") {
    const url = new URL(target.href);

    await router.render(url.pathname);
  }
}

async function logout() {
  await apiLogout();
  goto("/");
}

function updateNav() {
  const user = JSON.parse(sessionStorage.getItem("user"));
  if (user) {
    userEls.forEach((x) => (x.style.display = "block"));
    guestEls.forEach((x) => (x.style.display = "none"));
  } else {
    userEls.forEach((x) => (x.style.display = "none"));
    guestEls.forEach((x) => (x.style.display = "block"));
  }
}

export function showView(element) {
  mainEl.replaceChildren(element);
}
async function goto(path, ...params) {
  router.render(path, ...params);
}
