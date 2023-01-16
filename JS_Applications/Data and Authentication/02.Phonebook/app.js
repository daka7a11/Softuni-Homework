import * as api from "./data.js";

function attachEvents() {
  const loadBtn = document.querySelector("#btnLoad");
  const phonebookEl = document.querySelector("#phonebook");
  const loadingContactsLi = document.createElement("li");
  const createBtn = document.querySelector("#btnCreate");
  const personEl = document.querySelector("#person");
  const phoneEl = document.querySelector("#phone");

  loadBtn.addEventListener("click", renderData);
  createBtn.addEventListener("click", createContact);
  loadingContactsLi.textContent = "Loading contacts...";

  async function renderData(e) {
    e != undefined ? e.preventDefault() : "";

    phonebookEl.innerHTML = "";
    phonebookEl.appendChild(loadingContactsLi);
    const data = await api.loadDataAsync();
    phonebookEl.innerHTML = "";

    Object.entries(data).forEach(([k, v]) => {
      const li = document.createElement("li");
      li.textContent = `${v.person}:${v.phone}`;

      const deleteBtn = document.createElement("button");
      deleteBtn.textContent = "Delete";
      deleteBtn.addEventListener("click", async () => {
        deleteBtn.textContent = "Deleting...";
        deleteBtn.disabled = true;
        await api.deleteContactAsync(k);
        li.remove();
      });

      li.appendChild(deleteBtn);
      phonebookEl.appendChild(li);
    });
  }

  async function createContact(e) {
    e.preventDefault();

    await api.addContactAsync(personEl.value, phoneEl.value);

    personEl.value = "";
    phoneEl.value = "";

    renderData();
  }
}

attachEvents();
