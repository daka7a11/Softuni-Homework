import { html } from "../../node_modules/lit-html/lit-html.js";

export const navbarTemplate = (isAuthenticated) => {
  return html`<a href="/" class="site-logo">Team Manager</a>
    <nav>
      <a href="/teams" class="action">Browse Teams</a>
      ${isAuthenticated
        ? html` <a href="/logout" class="action">Logout</a>`
        : html`<a href="/login" class="action">Login</a>
            <a href="/register" class="action">Register</a>`}
    </nav>`;
};
