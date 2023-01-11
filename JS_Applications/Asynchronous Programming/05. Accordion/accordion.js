window.addEventListener("onLoad", solution());
function solution() {
  const baseUrl = "http://localhost:3030/jsonstore/advanced/articles";
  const mainSection = document.getElementById("main");

  fetch(baseUrl + "/list")
    .then((response) => response.json())
    .then((data) => renderArticles(data));

  function renderArticles(articles) {
    articles.forEach((article) => {
      const accorditionDiv = createElement(
        "div",
        "",
        ["accordion"],
        mainSection
      );

      const headDiv = createElement("div", "", ["head"], accorditionDiv);
      const spanEl = createElement("span", article.title, null, headDiv);
      const btn = createElement("button", "More", ["button"], headDiv);
      btn.id = article._id;
      btn.addEventListener("click", onClick);

      const extraDiv = createElement("div", "", ["extra"], accorditionDiv);
      extraDiv.style.display = "none";
      const extraPEl = createElement("p", "", null, extraDiv);
    });

    function onClick(e) {
      e.preventDefault();

      const extraDiv =
        e.target.parentElement.parentElement.querySelector("div .extra");

      if (e.target.textContent === "More") {
        const pEl = extraDiv.querySelector("p");

        fetch(baseUrl + "/details/" + e.target.id)
          .then((response) => response.json())
          .then((data) => {
            extraDiv.textContent = data.content;
          });

        extraDiv.style.display = "block";
        e.target.textContent = "Less";
      } else {
        extraDiv.style.display = "none";
        e.target.textContent = "More";
      }
    }
  }

  function createElement(tag, context, clases, parent) {
    clases = clases || [];
    const el = document.createElement(tag);
    el.textContent = context;

    clases.forEach((x) => {
      el.classList.add(x);
    });

    if (parent) {
      parent.appendChild(el);
    }
    return el;
  }
}
