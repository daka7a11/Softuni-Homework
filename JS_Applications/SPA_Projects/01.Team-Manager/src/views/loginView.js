import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as authService from "../services/authService.js";

const loginTemplate = (onSubmit, errMsg = null) => html`<section id="login">
  <article class="narrow">
    <header class="pad-med">
      <h1>Login</h1>
    </header>
    <form @submit=${onSubmit} id="login-form" class="main-form pad-large">
      ${errMsg.length != 0 ? html`<div class="error">${errMsg}</div>` : nothing}

      <label>E-mail: <input type="text" name="email" /></label>
      <label>Password: <input type="password" name="password" /></label>
      <input class="action cta" type="submit" value="Sign In" />
    </form>
    <footer class="pad-small">
      Don't have an account? <a href="/register" class="invert">Sign up here</a>
    </footer>
  </article>
</section>`;

export async function loginView(ctx, errMsg) {
  ctx.render(loginTemplate(onSubmit, errMsg));

  function onSubmit(e) {
    e.preventDefault();

    const { email, password } = Object.fromEntries(new FormData(e.target));
    authService
      .login(email, password)
      .then(() => {
        ctx.page.redirect("/");
      })
      .catch((err) => {
        loginView(ctx, err.message);
      });
  }
}
