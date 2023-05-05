import { html } from "./node_modules/lit-html/lit-html.js";

export function generateStudentTemplate(student) {
  return html` <tr>
    <td>${student.firstName} ${student.lastName}</td>
    <td>${student.email}</td>
    <td>${student.course}</td>
  </tr>`;
}
