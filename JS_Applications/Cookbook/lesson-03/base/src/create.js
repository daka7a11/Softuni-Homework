if (!sessionStorage.getItem("accessToken")) {
  location.href = "/Cookbook/lesson-03/base/login.html";
}

const baseUrl = "http://localhost:3030/";
const endPoint = "data/recipes";

const form = document.querySelector("form");

form.addEventListener("submit", create);

function create(e) {
  e.preventDefault();

  const formData = new FormData(form);

  const name = formData.get("name");
  const img = formData.get("img");
  const ingredients = formData.get("ingredients").split("\n");
  const steps = formData.get("steps").split("\n");

  const data = {
    name,
    img,
    ingredients,
    steps,
  };

  fetch(baseUrl + endPoint, {
    method: "POST",
    headers: {
      "content-type": "application/json",
      "X-Authorization": sessionStorage.getItem("accessToken"),
    },
    body: JSON.stringify(data),
  })
    .then((res) => res.json())
    .then((data) => {
      location.href = "/Cookbook/lesson-03/base/index.html";
    });
}
