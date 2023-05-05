import { html } from "../../node_modules/lit-html/lit-html.js";
import { login, register, logout } from "../api/data.js";

const loginTemplate = (onSubmit) => html`<div class="row space-top">
    <div class="col-md-12">
      <h1>Login User</h1>
      <p>Please fill all fields.</p>
    </div>
  </div>
  <form @submit=${onSubmit}>
    <div class="row space-top">
      <div class="col-md-4">
        <div class="form-group">
          <label class="form-control-label" for="email">Email</label>
          <input class="form-control" id="email" type="text" name="email" />
        </div>
        <div class="form-group">
          <label class="form-control-label" for="password">Password</label>
          <input
            class="form-control"
            id="password"
            type="password"
            name="password"
          />
        </div>
        <input type="submit" class="btn btn-primary" value="Login" />
      </div>
    </div>
  </form>`;
const registerTemplate = (onSubmit) => html`<div class="row space-top">
    <div class="col-md-12">
      <h1>Register New User</h1>
      <p>Please fill all fields.</p>
    </div>
  </div>
  <form @submit=${onSubmit}>
    <div class="row space-top">
      <div class="col-md-4">
        <div class="form-group">
          <label class="form-control-label" for="email">Email</label>
          <input class="form-control" id="email" type="text" name="email" />
        </div>
        <div class="form-group">
          <label class="form-control-label" for="password">Password</label>
          <input
            class="form-control"
            id="password"
            type="password"
            name="password"
          />
        </div>
        <div class="form-group">
          <label class="form-control-label" for="rePass">Repeat</label>
          <input
            class="form-control"
            id="rePass"
            type="password"
            name="rePass"
          />
        </div>
        <input type="submit" class="btn btn-primary" value="Register" />
      </div>
    </div>
  </form>`;

export async function loginPage(ctx) {
  ctx.render(loginTemplate(onSubmit));
  console.log("login");

  async function onSubmit(e) {
    e.preventDefault();
    const formData = new FormData(e.target);

    const email = formData.get("email");
    const password = formData.get("password");

    await login(email, password);
    ctx.page.redirect("/");
  }
}

export function registerPage(ctx) {
  ctx.render(registerTemplate(onSubmit));

  async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(e.target);

    const email = formData.get("email");
    const password = formData.get("password");
    const rePass = formData.get("rePass");

    if (email === "" || password === "") {
      return alert("All flieds are required!");
    }

    if (password !== rePass) {
      return alert("Passwords don't match!");
    }

    await register(email, password);

    ctx.page.redirect("/");
  }
}

export async function logoutPage(ctx) {
  await logout();
  ctx.page.redirect("/");
}
