import { html } from "../../node_modules/lit-html/lit-html.js";
import { until } from "../../node_modules/lit-html/directives/until.js";
import { deleteItem, getById } from "../api/data.js";
import { getUserData } from "../api/util.js";

const detailsTemplate = (itemPromise) => html`<div class="row space-top">
    <div class="col-md-12">
      <h1>Furniture Details</h1>
    </div>
  </div>
  ${until(itemPromise, html`<p>Loading &hellip;</p>`)}`;

const itemTemplate = (
  item,
  onDelete,
  isOwner
) => html`<div class="row space-top">
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src="${item.img}" />
        </div>
    </div>
</div>
<div class="col-md-4">
    <p>Make: <span>${item.make}</span></p>
    <p>Model: <span>${item.model}</span></p>
    <p>Year: <span>${item.year}</span></p>
    <p>Description: <span>${item.description}</span></p>
    <p>Price: <span>${item.price}</span></p>
    <p>Material: <span>${item.material}</span></p>
    ${
      isOwner
        ? html`<div>
            <a href="/edit/${item._id}" class="btn btn-info">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="btn btn-red"
              >Delete</a
            >
          </div>`
        : null
    }
    
</div>
</div>
</div>`;

export function detailsPage(ctx) {
  ctx.render(detailsTemplate(loadItem(ctx.params.id)));

  async function loadItem(id) {
    const item = await getById(id);

    const user = getUserData();

    const isOwner = user?._id === item._ownerId;

    return itemTemplate(item, onDelete, isOwner);
  }
  async function onDelete(e) {
    e.preventDefault();
    if (!confirm("Are you sure you want to delete this furniture?")) {
      return;
    }

    await deleteItem(ctx.params.id);

    ctx.page.redirect("/");
  }
}
