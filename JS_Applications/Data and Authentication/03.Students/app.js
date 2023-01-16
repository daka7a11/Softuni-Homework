import * as api from "./data.js";

window.addEventListener("load", solution);

function solution() {
  const tbodyEl = document.querySelector("#results tbody");
  const elements = {
    firstNameEl: document.querySelector('input[name="firstName"]'),
    lastNameEl: document.querySelector('input[name="lastName"]'),
    fNumberEl: document.querySelector('input[name="facultyNumber"]'),
    gradeEl: document.querySelector('input[name="grade"]'),
  };
  const submitFormBtn = document.querySelector("#submit");
  submitFormBtn.addEventListener("click", createStudent);

  renderStudents();

  async function renderStudents() {
    tbodyEl.innerHTML = "";
    const students = await api.getStudents();
    Object.entries(students).forEach(([studentId, info]) => {
      const tr = document.createElement("tr");
      tbodyEl.appendChild(tr);

      const fNameTd = document.createElement("td");
      fNameTd.textContent = info.firstName;
      tr.appendChild(fNameTd);

      const lNameTd = document.createElement("td");
      lNameTd.textContent = info.lastName;
      tr.appendChild(lNameTd);

      const fNumberTd = document.createElement("td");
      fNumberTd.textContent = info.facultyNumber;
      tr.appendChild(fNumberTd);

      const gradeTd = document.createElement("td");
      gradeTd.textContent = info.grade;
      tr.appendChild(gradeTd);
    });
  }

  async function createStudent(e) {
    let correctData = true;
    e.preventDefault();
    Object.entries(elements).forEach(([k, v]) => {
      if (!v.value) {
        v.style.borderColor = "red";
        correctData = false;
      } else {
        v.style.borderColor = "";
      }
    });

    if (!correctData) {
      submitFormBtn.style.backgroundColor = "red";
      return;
    } else {
      submitFormBtn.style.backgroundColor = "";
    }

    const student = {
      firstName: elements.firstNameEl.value,
      lastName: elements.lastNameEl.value,
      facultyNumber: elements.fNumberEl.value,
      grade: elements.gradeEl.value,
    };

    await api.createStudent(student);

    renderStudents();
  }
}
