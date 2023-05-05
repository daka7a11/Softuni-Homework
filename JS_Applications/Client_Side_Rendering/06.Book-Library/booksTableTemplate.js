import { html } from "./node_modules/lit-html/lit-html.js";
import { bookTemplate } from "./bookTrTemplate.js";

export function generateBooksTable(books) {
  return html` <table>
    <thead>
      <tr>
        <th>Title</th>
        <th>Author</th>
        <th>Action</th>
      </tr>
    </thead>
    <tbody>
      ${Object.keys(books).map((bookKey) =>
        bookTemplate(bookKey, books[bookKey])
      )}
    </tbody>
  </table>`;
}
