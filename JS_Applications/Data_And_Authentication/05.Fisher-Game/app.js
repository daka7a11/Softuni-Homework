import * as homeApi from "./src/home.js";
import * as loginApi from "./src/login.js";

const viewsEl = document.querySelector("#views");
viewsEl.style.display = "none";

const guestEl = document.getElementById("guest");
const userEl = document.getElementById("user");

renderHomePage();

function reloadNavBar() {
  if (!sessionStorage.getItem("accessToken")) {
    guestEl.style.display = "block";
    userEl.style.display = "none";
  } else {
    guestEl.style.display = "none";
    userEl.style.display = "block";
  }
}

function renderHomePage() {
  homeApi.renderHomePage();
  reloadNavBar();
}
