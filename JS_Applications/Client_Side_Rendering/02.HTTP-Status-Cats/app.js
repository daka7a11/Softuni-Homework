import { render, html } from "./node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";
import { generateCat } from "./catTemplate.js";

const sectionEl = document.querySelector("#allCats");

const mainTemplate = html` <ul>
  ${cats.map((cat) => generateCat(cat))}
</ul>`;

render(mainTemplate, sectionEl);
