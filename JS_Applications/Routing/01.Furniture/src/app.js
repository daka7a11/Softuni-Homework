import { render, html } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";
import { catalogPage } from "./views/catalog.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { loginPage, logoutPage, registerPage } from "./views/user.js";

import * as api from "./api/data.js";
import { getUserData } from "./api/util.js";

window.api = api;

const root = document.querySelector("div.container");

page(decorateContext);
page("/", catalogPage);
page("/create", createPage);
page("/details/:id", detailsPage);
page("/edit/:id", editPage);
page("/login", loginPage);
page("/register", registerPage);
page("/logout", logoutPage);
page("/my-furniture", catalogPage);

page.start();

function decorateContext(ctx, next) {
  ctx.render = (content) => render(content, root);
  ctx.updateNav = updateNav;
  next();
}

function updateNav() {
  const userDiv = document.querySelector("#user");
  const guestDiv = document.querySelector("#guest");

  const user = getUserData();

  if (user) {
    userDiv.style.display = "inline-block";
    guestDiv.style.display = "none";
  } else {
    userDiv.style.display = "none";
    guestDiv.style.display = "inline-block";
  }
}
