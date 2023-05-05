import { render } from "../../node_modules/lit-html/lit-html.js";
import { navbarTemplate } from "../views/navbar.js";

const navBar = document.querySelector("#titlebar");
const mainEl = document.querySelector("main");

function ctxRender(ctx, templateResult) {
  render(templateResult, mainEl);

  render(navbarTemplate(ctx.isAuthenticated), navBar);
}

export function renderMiddleware(ctx, next) {
  ctx.render = ctxRender.bind("null", ctx);

  next();
}
