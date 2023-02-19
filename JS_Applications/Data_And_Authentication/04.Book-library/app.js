import * as api from "./data.js";

const loadBtn = document.getElementById("loadBooks");
const tbodyEl = document.querySelector("tbody");
const formEl = document.querySelector("form");
const createBtn = formEl.querySelector("#createBtn");
const editBtn = document.querySelector("#editBtn");
const cancelBtn = document.querySelector("#cancelBtn");

const titleEl = formEl.querySelector("input[name='title'");
const authorEl = formEl.querySelector("input[name='author'");

loadBtn.addEventListener("click", loadBooks);
//createBtn.addEventListener("click", createBook);

formEl.addEventListener("click", formHandler);

async function formHandler(e) {
  e.preventDefault();
  const target = e.target;

  if (target.tagName !== "BUTTON") {
    return;
  }

  if (target.textContent === "Submit") {
    createBook(e);
  } else if (target.textContent === "Save") {
    if (!(titleEl.value && authorEl.value)) {
      alert("Invalid data!");
      return;
    }

    const bookId = localStorage.getItem("bookId");

    await api.editBook(bookId, {
      title: titleEl.value,
      author: authorEl.value,
    });

    titleEl.value = "";
    authorEl.value = "";
    createBtn.style.display = "";
    editBtn.style.display = "none";
    cancelBtn.style.display = "none";

    loadBooks(e);
  } else if (target.textContent === "Cancel") {
    titleEl.value = "";
    authorEl.value = "";
    createBtn.style.display = "";
    editBtn.style.display = "none";
    cancelBtn.style.display = "none";

    loadBooks(e);
  } else {
    return;
  }
}

async function loadBooks(e) {
  e.preventDefault();
  tbodyEl.innerHTML = "";
  const data = await api.getBooks();

  Object.entries(data).forEach(([id, book]) => {
    const tr = createTr(id, book.title, book.author);
    tbodyEl.appendChild(tr);
  });

  console.log("loadBooks");
}

async function createBook(e) {
  e.preventDefault();

  const formData = new FormData(formEl);

  const title = formData.get("title");
  const author = formData.get("author");

  if (!(title && author)) {
    alert("Invalid data!");
    return;
  }

  await api.createBook({ title, author });

  formEl.reset();

  console.log("createBook");

  loadBooks(e);
}

function createTr(id, title, author) {
  const tr = document.createElement("tr");
  tr.setAttribute("id", id);

  const tdTitle = document.createElement("td");
  tdTitle.setAttribute("name", "title");
  tdTitle.textContent = title;

  const tdAuthor = document.createElement("td");
  tdAuthor.setAttribute("name", "author");
  tdAuthor.textContent = author;

  const tdAction = document.createElement("td");

  const editBtn = document.createElement("button");
  editBtn.textContent = "Edit";
  editBtn.addEventListener("click", editBook);

  const deleteBtn = document.createElement("button");
  deleteBtn.textContent = "Delete";
  deleteBtn.addEventListener("click", deleteBook);

  tdAction.appendChild(editBtn);
  tdAction.appendChild(deleteBtn);

  tr.appendChild(tdTitle);
  tr.appendChild(tdAuthor);
  tr.appendChild(tdAction);

  return tr;
}

async function editBook(e) {
  e.preventDefault();
  const tr = e.target.closest("tr");
  localStorage.setItem("bookId", tr.id);

  const title = tr.querySelector("td[name='title']").textContent;
  const author = tr.querySelector("td[name='author']").textContent;

  createBtn.style.display = "none";
  editBtn.style.display = "block";
  cancelBtn.style.display = "block";

  titleEl.value = title;
  authorEl.value = author;

  //console.log("editBook");
  //SOMETHING HAPPEN HERE !!!
  // editBtn.addEventListener("click", async function saveHandler(e) {
  //   e.preventDefault();
  //   if (!(titleEl.value && authorEl.value)) {
  //     alert("Invalid data!");
  //     return;
  //   }

  //   await api.editBook(tr.id, { title: titleEl.value, author: authorEl.value });

  //   titleEl.value = "";
  //   authorEl.value = "";
  //   createBtn.style.display = "";
  //   editBtn.style.display = "none";
  //   cancelBtn.style.display = "none";

  //   console.log("saveHandler1");

  //   editBtn.removeEventListener("click", saveHandler, true);

  //   console.log("saveHandler2");

  //   loadBooks(e);
  // });

  // cancelBtn.addEventListener("click", async function cancelHandler(e) {
  //   e.preventDefault();

  //   titleEl.value = "";
  //   authorEl.value = "";
  //   createBtn.style.display = "";
  //   editBtn.style.display = "none";
  //   cancelBtn.style.display = "none";

  //   console.log("cancelHandler1");

  //   editBtn.removeEventListener("click", cancelHandler, true);

  //   console.log("cancelHandler2");
  // });
}

async function deleteBook(e) {
  e.preventDefault();

  const tr = e.target.closest("tr");

  tr.remove();

  await api.deleteBook(tr.id);
}
