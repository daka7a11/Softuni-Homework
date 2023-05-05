import { render, html } from "./node_modules/lit-html/lit-html.js";

const url = "http://localhost:3030/jsonstore/advanced/dropdown";

const selectEl = document.querySelector("#menu");
const itemEl = document.querySelector("#itemText");
const submitInput = document.querySelector("input[type=submit]");

submitInput.addEventListener("click", addItem);

renderOptions();

async function addItem(e) {
  e.preventDefault();

  const text = itemEl.value;

  const res = await fetch(url, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ text }),
  });

  debugger;

  if (res.status !== 200) {
    const err = await res.json;
    console.log(err);
    return;
  }

  itemEl.value = "";

  await renderOptions();
}

function optionTemplate(opt) {
  return html`<option value=${opt._id}>${opt.text}</option>`;
}

async function getOptions() {
  return Object.values(await (await fetch(url)).json());
}

async function renderOptions() {
  const opts = await getOptions();

  render(
    opts.map((opt) => optionTemplate(opt)),
    selectEl
  );
}
