const catalogPageEl = document.querySelector("#catalogPage");

const editEl = document.querySelector("#edit");
const formEl = editEl.querySelector("form");

formEl.addEventListener("submit", (ev) => {
  ev.preventDefault();
  const formData = new FormData(ev.target);
  onSubmit(
    [...formData.entries()].reduce(
      (p, [k, v]) => Object.assign(p, { [k]: v }),
      {}
    )
  );
});

export async function renderEdit(id) {
  const recipe = await (
    await fetch("http://localhost:3030/data/recipes/" + id)
  ).json();

  console.log(recipe);

  editEl.style.display = "block";

  editEl.id = id;
  editEl.querySelector('input[name="name"]').value = recipe.name;
  editEl.querySelector("input[name='img']").value = recipe.img;
  editEl.querySelector("textarea[name='ingredients']").value =
    recipe.ingredients.join("\n");
  editEl.querySelector("textarea[name='steps']").value =
    recipe.steps.join("\n");

  console.log(recipe);

  console.log(id);
}

async function onSubmit(data) {
  const body = JSON.stringify({
    name: data.name,
    img: data.img,
    ingredients: data.ingredients
      .split("\n")
      .map((l) => l.trim())
      .filter((l) => l != ""),
    steps: data.steps
      .split("\n")
      .map((l) => l.trim())
      .filter((l) => l != ""),
  });

  const token = sessionStorage.getItem("authToken");
  if (token == null) {
    alert("You don't have permission to edit the recipe!");
    catalogPageEl.click();
    return;
  }

  try {
    const response = await fetch(
      "http://localhost:3030/data/recipes/" + editEl.id,
      {
        method: "put",
        headers: {
          "Content-Type": "application/json",
          "X-Authorization": token,
        },
        body,
      }
    );

    if (response.status == 200) {
      alert("Successfully edited recipe!");
      catalogPageEl.click();
    } else {
      throw new Error(await response.json());
    }
  } catch (err) {
    console.error(err.message);
  }
}
