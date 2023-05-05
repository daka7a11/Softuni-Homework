import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as authService from "../services/authService.js";

const registerTemplate = (onSubmit, errMsg = null) => html`<section
  id="register"
>
  <article class="narrow">
    <header class="pad-med">
      <h1>Register</h1>
    </header>
    <form @submit=${onSubmit} id="register-form" class="main-form pad-large">
      ${errMsg.length != 0 ? html`<div class="error">${errMsg}</div>` : nothing}
      <label>E-mail: <input type="text" name="email" /></label>
      <label>Username: <input type="text" name="username" /></label>
      <label>Password: <input type="password" name="password" /></label>
      <label>Repeat: <input type="password" name="repass" /></label>
      <input class="action cta" type="submit" value="Create Account" />
    </form>
    <footer class="pad-small">
      Already have an account? <a href="/login" class="invert">Sign in here</a>
    </footer>
  </article>
</section>`;

export async function registerView(ctx, errMsg) {
  ctx.render(registerTemplate(onSubmit, errMsg));

  function onSubmit(e) {
    e.preventDefault();

    const { email, password, username, repass } = Object.fromEntries(
      new FormData(e.target)
    );

    if (password != repass) {
      loginView(ctx, "The passwords do not match!");
    }
    authService
      .register({ email, password, username })
      .then(() => {
        ctx.page.redirect("/");
      })
      .catch((err) => {
        loginView(ctx, err.message);
      });
  }
}
