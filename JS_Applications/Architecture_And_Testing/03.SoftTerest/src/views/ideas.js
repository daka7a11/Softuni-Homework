import { getIdeas } from "../api.js";

const ideasEl = document.querySelector(".ideasPage");
ideasEl.addEventListener("click", detailsHandler);

let context = null;

export async function renderIdeas(inputContext) {
  context = inputContext;
  const ideas = await getIdeas();
  ideasEl.replaceChildren();
  if (ideas.length > 0) {
    ideas.forEach((x) => ideasEl.appendChild(createIdeaEl(x)));
  } else {
    ideasEl.appendChild(noIdeaView());
  }
  context.showView(ideasEl);
}

function createIdeaEl(idea) {
  const div = document.createElement("div");
  //div.id = idea._id;
  div.setAttribute("data-id", idea._id);
  div.className = `card overflow-hidden current-card details`;
  div.style = "width: 20rem; height: 18rem;";
  div.innerHTML = `
    <div class="card-body">
     <p class="card-text">${idea.title}</p>
     </div>
     <img class="card-image" src="${idea.img}" alt="Card image cap">
     <a class="btn" href="/details">Details</a>
  `;
  return div;
}

function noIdeaView() {
  const h1 = document.createElement("h1");
  h1.textContent = "No ideas yet! Be the first one :)";
  return h1;
}

function detailsHandler(e) {
  e.preventDefault();

  if (e.target.tagName !== "A") {
    return;
  }

  const ideaId = e.target.closest("div.card").dataset.id;

  context.goto("/details", ideaId);
}
