import { html, render } from "./node_modules/lit-html/lit-html.js";
import { addBookTemplate } from "./addBookTemplate.js";

const url = "http://localhost:3030/jsonstore/collections/books";

export function editBookTemplate(bookId, book) {
  return html` <form id="edit-form">
    <input type="hidden" name="id" value="${bookId}" />
    <h3>Edit book</h3>
    <label>TITLE</label>
    <input type="text" name="title" value="${book.title}" />
    <label>AUTHOR</label>
    <input type="text" name="author" value="${book.author}" />
    <input type="submit" value="Save" @click="${onSubmit}" />
  </form>`;

  async function onSubmit(e) {
    e.preventDefault();

    const formEl = document.querySelector("#edit-form");
    const formData = new FormData(formEl);

    const title = formData.get("title");
    const author = formData.get("author");

    const res = await fetch(url + `/${bookId}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ title, author }),
    });

    if (res.status !== 200) {
      const err = await res.json();
      alert(err.message);
      throw new Error(err.message);
    }

    formEl.reset();

    alert("Edited!");

    const formDivEl = document.querySelector(".form-container");
    render(addBookTemplate(), formDivEl);

    document.querySelector("#loadBooks").click();
  }
}
