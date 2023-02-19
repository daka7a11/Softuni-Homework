import { createIdea } from "../api.js";

const createEl = document.querySelector(".createPage");
const formEl = createEl.querySelector("form");
formEl.addEventListener("submit", submit);

let context = null;

export function renderCreate(inputContext) {
  context = inputContext;
  context.showView(createEl);
}

async function submit(e) {
  e.preventDefault();
  const formData = new FormData(formEl);

  const title = formData.get("title");
  const description = formData.get("description");
  const img = formData.get("imageURL");

  const idea = {
    title,
    description,
    img,
  };

  const createdIdea = await createIdea(idea);
  alert(`${createdIdea.title} created!`);
  formEl.reset();
  context.goto("/ideas");
}
