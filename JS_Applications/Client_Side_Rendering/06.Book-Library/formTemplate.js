import { html } from "./node_modules/lit-html/lit-html.js";

export function formTemplate(formEl) {
  return html`<div class="form-container">${formEl}</div>`;
}
