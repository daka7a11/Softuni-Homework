import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { until } from "../../node_modules/lit-html/directives/until.js";
import * as dataService from "../services/dataService.js";

const teamsTemplate = (dataPromise, isAuthenticated) => html`<section
  id="browse"
>
  <article class="pad-med">
    <h1>Team Browser</h1>
  </article>
  ${isAuthenticated
    ? html`<article class="layout narrow">
        <div class="pad-small">
          <a href="/create" class="action cta">Create Team</a>
        </div>
      </article>`
    : nothing}
  ${until(dataPromise, html`<p>Loading &hellip;</p>`)}
</section>`;

const teamTemplate = (team) => html`<article class="layout">
  <img src="${team.logoUrl}" class="team-logo left-col" />
  <div class="tm-preview">
    <h2>${team.name}</h2>
    <p>${team.description}</p>
    <span class="details">${team.membersCount}</span>
    <div><a href="/details/${team._id}" class="action">See details</a></div>
  </div>
</article>`;

export function teamsView(ctx) {
  ctx.render(teamsTemplate(loadTeams(), ctx.isAuthenticated));
}

async function loadTeams() {
  const items = await dataService.getAllTeams();

  const members = await dataService.getAllMembers();

  items.forEach((team) => {
    const currTeamMembers = members.filter((m) => m.teamId === team._id).length;
    team.membersCount = currTeamMembers;
  });

  return items.map((item) => teamTemplate(item));
}
