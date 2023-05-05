import { html } from "../../node_modules/lit-html/lit-html.js";
import { until } from "../../node_modules/lit-html/directives/until.js";
import { getAll, getMyItems } from "../api/data.js";
import { getUserData } from "../api/util.js";

const catalogTemplate = (dataPromise, isDashboard) => html` <div
    class="row space-top"
  >
    <div class="col-md-12">
      ${isDashboard
        ? html` <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>`
        : html` <h1>My Furniture</h1>
            <p>This is a list of your publications.</p>`}
    </div>
  </div>
  <div class="row space-top">
    ${until(dataPromise, html`<p>Loading &hellip;</p>`)}
  </div>`;

const furnitureTemplate = (item) => html` <div class="col-md-4">
  <div class="card text-white bg-primary">
    <div class="card-body">
      <img src="${item.img}" />
      <p>${item.description}</p>
      <footer>
        <p>Price: <span>${item.price} $</span></p>
      </footer>
      <div>
        <a href="/details/${item._id}" class="btn btn-info">Details</a>
      </div>
    </div>
  </div>
</div>`;

export function catalogPage(ctx) {
  const isDashboard = ctx.pathname === "/";
  ctx.updateNav();
  ctx.render(catalogTemplate(loadItems(isDashboard), isDashboard));

  async function loadItems(isDashboard) {
    let items = null;

    if (!isDashboard) {
      const userData = getUserData();
      items = await getMyItems(userData?._id);
    } else {
      items = await getAll();
    }
    return items.map((i) => furnitureTemplate(i));
  }
}
