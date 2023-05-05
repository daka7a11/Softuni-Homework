import { html } from "../../node_modules/lit-html/lit-html.js";
import { until } from "../../node_modules/lit-html/directives/until.js";
import { editItem, getById } from "../api/data.js";

const editTemplate = (itemPromise) => html`<div class="row space-top">
<div class="col-md-12">
    <h1>Edit Furniture</h1>
    <p>Please fill all fields.</p>
</div>
</div>
${until(itemPromise, html`<p>Loading &hellip;</p>`)}
</div>`;

const formTemplate = (item, onSubmit) => html` <form @submit=${onSubmit}>
  <div class="row space-top">
    <div class="col-md-4">
      <div class="form-group">
        <label class="form-control-label" for="new-make">Make</label>
        <input
          class="form-control"
          id="new-make"
          type="text"
          name="make"
          .value=${item.make}
        />
      </div>
      <div class="form-group has-success">
        <label class="form-control-label" for="new-model">Model</label>
        <input
          class="form-control"
          id="new-model"
          type="text"
          name="model"
          .value=${item.model}
        />
      </div>
      <div class="form-group has-danger">
        <label class="form-control-label" for="new-year">Year</label>
        <input
          class="form-control"
          id="new-year"
          type="number"
          name="year"
          .value=${item.year}
        />
      </div>
      <div class="form-group">
        <label class="form-control-label" for="new-description"
          >Description</label
        >
        <input
          class="form-control"
          id="new-description"
          type="text"
          name="description"
          .value=${item.description}
        />
      </div>
    </div>
    <div class="col-md-4">
      <div class="form-group">
        <label class="form-control-label" for="new-price">Price</label>
        <input
          class="form-control"
          id="new-price"
          type="number"
          name="price"
          .value=${item.price}
        />
      </div>
      <div class="form-group">
        <label class="form-control-label" for="new-image">Image</label>
        <input
          class="form-control"
          id="new-image"
          type="text"
          name="img"
          .value=${item.img}
        />
      </div>
      <div class="form-group">
        <label class="form-control-label" for="new-material"
          >Material (optional)</label
        >
        <input
          class="form-control"
          id="new-material"
          type="text"
          name="material"
          .value=${item.material}
        />
      </div>
      <input type="submit" class="btn btn-info" value="Edit" />
    </div>
  </div>
</form>`;

export function editPage(ctx) {
  ctx.render(editTemplate(loadItem(ctx.params.id)));

  async function loadItem(id) {
    const item = await getById(id);

    return formTemplate(item, onSubmit);
  }

  async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(e.target);

    const make = formData.get("make").trim();
    const model = formData.get("model").trim();
    const year = Number(formData.get("year").trim());
    const description = formData.get("description").trim();
    const price = Number(formData.get("price").trim());
    const img = formData.get("img").trim();
    const material = formData.get("material").trim();

    if (!(make && model && year && description && price && img)) {
      return alert("Please fill all required fields with correct data!");
    }

    try {
      const item = await editItem(ctx.params.id, {
        make,
        model,
        year,
        description,
        price,
        img,
        material,
      });

      ctx.page.redirect("/details/" + item._id);
    } catch (err) {
      ctx.page.redirect("/");
    }
  }
}
