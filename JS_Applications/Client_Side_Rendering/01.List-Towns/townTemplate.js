import { html } from "./node_modules/lit-html/lit-html.js";

export function generateTownItem(town) {
  return html`<li>${town}</li>`;
}
