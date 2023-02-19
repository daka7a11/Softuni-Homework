import { getIdeaById } from "../api.js";
import { deleteIdea } from "../api.js";

const ideasEl = document.querySelector(".ideasPage");

let context = null;

export async function renderDetails(inputContext, id) {
  context = inputContext;

  const idea = await getIdeaById(id);

  const user = JSON.parse(sessionStorage.getItem("user"));
  let isAuthorized = false;
  if (user && idea._ownerId === user._id) {
    isAuthorized = true;
  }

  const ideaEl = createIdeaEl(idea, isAuthorized);
  context.showView(ideaEl);
}

function createIdeaEl(idea, isAuthorized) {
  const div = document.createElement("div");
  div.className = "container home some detailsPage";
  div.innerHTML = `
    <img class="det-img" src="${idea.img}" />
    <div class="desc">
        <h2 class="display-5">${idea.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${idea.description}</p>
    </div>`;

  if (isAuthorized) {
    const aDiv = document.createElement("div");
    aDiv.className = "text-center";
    const delAnch = document.createElement("a");
    delAnch.className = "btn detb";
    delAnch.textContent = "Delete";
    delAnch.setAttribute("data-id", idea._id);

    aDiv.appendChild(delAnch);

    delAnch.addEventListener("click", del);

    div.appendChild(aDiv);
  }

  return div;
}

async function del(e) {
  e.preventDefault();

  if (!confirm("Are you sure you want to delete the idea?")) {
    return;
  }

  await deleteIdea(e.target.dataset.id);

  context.goto("/");
}
