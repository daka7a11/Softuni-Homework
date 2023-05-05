import { html } from "./node_modules/lit-html/lit-html.js";
import { generateTownItem } from "./townTemplate.js";

export function generateTownList(towns) {
  return html`
    <ul>
      ${towns.map((town) => generateTownItem(town))}
    </ul>
  `;
}
