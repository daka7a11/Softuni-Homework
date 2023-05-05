import { render, html } from "./node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";
import { generateTownItem } from "./townTemplate.js";

const townsEl = document.querySelector("#towns");
const resultEl = document.querySelector("#result");

const searchInput = document.querySelector("#searchText");

searchInput.addEventListener("input", search);

const searchBtn = document.querySelector("article button");
searchBtn.addEventListener("click", search);

const mainTemplate = generateMainTemplate(towns);

render(mainTemplate, townsEl);

function search(e) {
  e.preventDefault();

  const searchText = searchInput.value;

  const filteredTowns = towns.filter((town) =>
    town.toLowerCase().includes(searchText.toLowerCase())
  );

  render(generateMainTemplate(filteredTowns), resultEl);
}

function generateMainTemplate(towns) {
  return html` <ul>
    ${towns.map((town) => generateTownItem(town))}
  </ul>`;
}
