import { html, render } from "./node_modules/lit-html/lit-html.js";
import { editBookTemplate } from "./editBookTemplate.js";

export function bookTemplate(bookId, book) {
  return html` <tr>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td>
      <button @click="${editBook}">Edit</button>
      <button @click="${deleteBook}">Delete</button>
    </td>
  </tr>`;

  function editBook(e) {
    e.preventDefault();
    console.log("EDIT: " + bookId);

    const formDivEl = document.querySelector(".form-container");

    formDivEl.replaceChildren();

    render(editBookTemplate(bookId, book), formDivEl);
  }

  function deleteBook(e) {
    e.preventDefault();
    console.log("Delete: " + bookId);
  }
}
