window.addEventListener("load", solution);

function getUrl(endpoint) {
  return `http://localhost:3030/jsonstore/cookbook/${endpoint}`;
}

function solution() {
  const mainEl = document.querySelector("main");
  mainEl.innerHTML = "";
  fetch(getUrl("recipes"))
    .then((res) => res.json())
    .then((data) => {
      //TODO: DOM elements should be created in different way!
      Object.values(data).forEach((x) => {
        mainEl.innerHTML += `<article id="${x._id}" class="preview"><div class="title"><h2>${x.name}</h2></div><div class="small"><img src="${x.img}"></div></article>`;
      });
    });

  mainEl.addEventListener("click", (e) => {
    const articleEl = e.target.closest(".preview");
    if (articleEl === null) {
      return;
    }

    fetch(getUrl(`details/${articleEl.id}`))
      .then((res) => res.json())
      .then((data) => {
        const fullArticleEl = createFullArticleEl(data);
        articleEl.replaceWith(fullArticleEl);
      });
  });

  function createFullArticleEl(recipe) {
    const article = document.createElement("article");

    const recipeTitle = document.createElement("h2");
    recipeTitle.textContent = recipe.name;
    article.appendChild(recipeTitle);

    const divBand = document.createElement("div");
    divBand.classList.add("band");
    article.appendChild(divBand);

    const divThumb = document.createElement("div");
    divThumb.classList.add("thumb");
    divBand.appendChild(divThumb);

    const img = document.createElement("img");
    img.src = recipe.img;
    divThumb.appendChild(img);

    const divIngr = document.createElement("div");
    divIngr.classList.add("ingredients");
    divBand.appendChild(divIngr);

    const ingredientsTitle = document.createElement("h3");
    ingredientsTitle.textContent = "Ingredients:";
    divIngr.appendChild(ingredientsTitle);

    const ul = document.createElement("ul");
    divIngr.appendChild(ul);

    recipe.ingredients.forEach((x) => {
      const li = document.createElement("li");
      li.textContent = x;
      ul.appendChild(li);
    });

    const divDesc = document.createElement("div");
    divDesc.classList.add("description");
    article.appendChild(divDesc);

    const prepTitle = document.createElement("h3");
    prepTitle.textContent = "Preparation:";

    recipe.steps.forEach((x) => {
      const p = document.createElement("p");
      p.textContent = x;
      divDesc.appendChild(p);
    });

    return article;
  }
}
