const catalogPageEl = document.querySelector("#catalogPage");
const createEl = document.querySelector("#create");
const form = createEl.querySelector("form");

form.addEventListener("submit", (ev) => {
  ev.preventDefault();
  const formData = new FormData(ev.target);
  onSubmit(
    [...formData.entries()].reduce(
      (p, [k, v]) => Object.assign(p, { [k]: v }),
      {}
    )
  );
});

export function renderCreate() {
  createEl.style.display = "block";
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
    alert("You don't have permission to add recipe!");
    catalogPageEl.click();
    return;
  }

  try {
    const response = await fetch("http://localhost:3030/data/recipes", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
        "X-Authorization": token,
      },
      body,
    });

    if (response.status == 200) {
      alert("Successfully added new recipe!");
      catalogPageEl.click();
    } else {
      throw new Error(await response.json());
    }
  } catch (err) {
    console.error(err.message);
  }
}
