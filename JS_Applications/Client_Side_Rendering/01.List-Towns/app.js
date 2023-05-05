import { render } from "./node_modules/lit-html/lit-html.js";
import { generateTownList } from "./townsTeplate.js";

const rootEl = document.querySelector("#root");
const townsInput = document.querySelector("#towns");
const loadBtn = document.querySelector("#btnLoadTowns");

loadBtn.addEventListener("click", loadTowns);

function loadTowns(e) {
  e.preventDefault();

  const towns = townsInput.value.split(", ");

  render(generateTownList(towns), rootEl);
}
