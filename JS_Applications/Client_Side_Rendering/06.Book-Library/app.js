import { render, html } from "./node_modules/lit-html/lit-html.js";
import { loadBooksTemplate } from "./loadBooksTemplate.js";
import { addBookTemplate } from "./addBookTemplate.js";
import { formTemplate } from "./formTemplate.js";
import { generateBooksTable } from "./booksTableTemplate.js";

const bodyEl = document.body;
const url = "http://localhost:3030/jsonstore/collections/books";

renderTemplates(loadBooksTemplate(), formTemplate(addBookTemplate()));

const loadBooksBtn = document.querySelector("#loadBooks");
loadBooksBtn.addEventListener("click", loadBooks);

async function getBooks() {
  const res = await fetch(url);

  if (res.status !== 200) {
    const err = await res.json();
    alert(err.message);
    throw new Error(err.message);
  }

  return await res.json();
}

async function loadBooks() {
  const books = await getBooks();

  renderTemplates(
    loadBooksTemplate(),
    generateBooksTable(books),
    formTemplate(addBookTemplate())
  );
}

function renderTemplates(...temps) {
  render(temps, bodyEl);
}
