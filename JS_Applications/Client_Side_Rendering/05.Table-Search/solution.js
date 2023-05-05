import { render } from "./node_modules/lit-html/lit-html.js";
import { generateStudentTemplate } from "./studentTemplate.js";

const url = "http://localhost:3030/jsonstore/advanced/table";

const tbodyEl = document.querySelector(".container tbody");

document.querySelector("#searchBtn").addEventListener("click", onClick);
const students = await getStudents();
const studentsTemplate = students.map((st) => generateStudentTemplate(st));

render(studentsTemplate, tbodyEl);

function onClick(e) {
  const searchText = document.querySelector("#searchField").value.toLowerCase();

  resetSearch();
  const tds = tbodyEl.querySelectorAll("td");
  tds.forEach((td) => {
    const content = td.textContent.toLowerCase();
    if (content.includes(searchText)) {
      const tr = td.parentElement;
      if (!tr.classList.contains("select")) {
        tr.classList.add("select");
      }
    }
  });
}

function resetSearch() {
  tbodyEl.querySelectorAll("tr").forEach((tr) => tr.classList.remove("select"));
}

async function getStudents() {
  const res = await fetch(url);

  if (res.status !== 200) {
    const err = await res.json();
    alert(err.message);
    throw new Error(err.message);
  }

  return Object.values(await res.json());
}
