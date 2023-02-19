import { renderEdit } from "./edit.js";

const catalogPageEl = document.querySelector("#catalogPage");
const homeEl = document.querySelector("#catalog");
const loadingEl = document.querySelector("#loading");

async function getRecipes() {
  const response = await fetch("http://localhost:3030/data/recipes");
  const recipes = await response.json();

  return recipes;
}

async function getRecipeById(id) {
  const response = await fetch("http://localhost:3030/data/recipes/" + id);
  const recipe = await response.json();

  return recipe;
}
function createRecipePreview(recipe) {
  const result = e(
    "article",
    { className: "preview", onClick: toggleCard },
    e("div", { className: "title" }, e("h2", {}, recipe.name)),
    e("div", { className: "small" }, e("img", { src: recipe.img }))
  );

  return result;

  async function toggleCard() {
    const fullRecipe = await getRecipeById(recipe._id);

    result.replaceWith(await createRecipeCard(fullRecipe));
  }
}

async function createRecipeCard(recipe) {
  const result = e(
    "article",
    { id: recipe._id },
    e("h2", {}, recipe.name),
    e(
      "div",
      { className: "band" },
      e("div", { className: "thumb" }, e("img", { src: recipe.img })),
      e(
        "div",
        { className: "ingredients" },
        e("h3", {}, "Ingredients:"),
        e(
          "ul",
          {},
          recipe.ingredients.map((i) => e("li", {}, i))
        )
      )
    ),
    e(
      "div",
      { className: "description" },
      e("h3", {}, "Preparation:"),
      recipe.steps.map((s) => e("p", {}, s))
    )
  );

  const btnsDiv = e(
    "div",
    {
      className: "recipeButtons",
      style: "display: flex; justify-content: flex-end",
      onClick: recipeBtnHandler,
    },
    e("button", { id: "recipeEdit" }, "Edit"),
    e("button", { id: "recipeDelete" }, "Delete")
  );

  result.appendChild(btnsDiv);

  if (recipe._ownerId !== sessionStorage.getItem("userId")) {
    btnsDiv.style.display = "none";
  }

  return result;

  async function recipeBtnHandler(e) {
    e.preventDefault();

    const modifyRecipe = {
      recipeEdit: editRecipe,
      recipeDelete: deleteRecipe,
    };

    if (e.target.tagName !== "BUTTON") {
      return;
    }

    const recipeId = e.target.closest("article").id;

    const fullRecipe = await getRecipeById(recipeId);

    if (fullRecipe._ownerId !== sessionStorage.getItem("userId")) {
      alert("You don't have permission!");
      catalogPageEl.click();
      return;
    }

    await modifyRecipe[e.target.id](recipeId);

    console.log(e.target.textContent);
    console.log(e.target.id);
  }
}

async function editRecipe(id) {
  homeEl.style.display = "none";

  await renderEdit(id);
}
async function deleteRecipe(id) {
  const token = sessionStorage.getItem("authToken");

  fetch("http://localhost:3030/data/recipes/" + id, {
    method: "DELETE",
    headers: {
      "X-Authorization": token,
    },
  })
    .then(async (res) => {
      if (res.status === 200) {
        res.json();
      } else {
        throw new Error(await res.json());
      }
    })
    .then((data) => {
      alert("Recipe is deleted successfully!");
    })
    .catch((err) => {
      alert("Error: " + err.message);
    })
    .finally(() => catalogPageEl.click());
}
export async function renderHome() {
  //.
  loadingEl.style.display = "block";
  const recipes = await getRecipes();
  const cards = recipes.map(createRecipePreview);

  homeEl.innerHTML = "";
  cards.forEach((c) => homeEl.appendChild(c));

  loadingEl.style.display = "none";
  homeEl.style.display = "block";
}

function e(type, attributes, ...content) {
  const result = document.createElement(type);

  for (let [attr, value] of Object.entries(attributes || {})) {
    if (attr.substring(0, 2) == "on") {
      result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
    } else {
      result[attr] = value;
    }
  }

  content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

  content.forEach((e) => {
    if (typeof e == "string" || typeof e == "number") {
      const node = document.createTextNode(e);
      result.appendChild(node);
    } else {
      result.appendChild(e);
    }
  });

  return result;
}
