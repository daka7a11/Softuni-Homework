import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { until } from "../../node_modules/lit-html/directives/until.js";
import * as dataService from "../services/dataService.js";

const errorMessage = "All fields are required!";

const editTemplate = (dataPromise) => html`<section id="edit">
  <article class="narrow">
    <header class="pad-med">
      <h1>Edit Team</h1>
    </header>
    ${until(dataPromise, html`<p>Loading &hellip;</p>`)}
  </article>
</section>`;

const editFormTemplate = (data, onSubmit, errMsg) => html`<form
  id="edit-form"
  class="main-form pad-large"
  @submit=${onSubmit}
>
  ${errMsg.length != 0 ? html`<div class="error">${errMsg}</div>` : nothing}
  <label
    >Team name: <input type="text" name="name" .value=${data.name}
  /></label>
  <label
    >Logo URL: <input type="text" name="logoUrl" .value=${data.logoUrl}
  /></label>
  <label
    >Description:
    <textarea name="description" .value=${data.description}></textarea>
  </label>
  <input class="action cta" type="submit" value="Save Changes" />
</form>`;

export function editView(ctx, errMsg) {
  ctx.render(editTemplate(loadTeam(ctx, errMsg)));
}

async function loadTeam(ctx, errMsg) {
  const team = await dataService.getTeamById(ctx.params.teamId);

  console.log(team);

  return editFormTemplate(team, onSubmit, errMsg);

  async function onSubmit(e) {
    e.preventDefault();

    const { name, logoUrl, description } = Object.fromEntries(
      new FormData(e.target)
    );

    if (!(name && logoUrl && description)) {
      editView(ctx, errorMessage);
      return;
    }

    team.name = name;
    team.logoUrl = logoUrl;
    team.description = description;

    dataService.editTeam(team._id, team).catch((err) => {
      alert(err.message);
      ctx.page.redirect("/");
    });

    ctx.page.redirect("/teams");
  }
}
