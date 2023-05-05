import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { until } from "../../node_modules/lit-html/directives/until.js";

import * as dataService from "../services/dataService.js";
import { getUserData } from "../services/authService.js";

const detailsLayout = (dataPromise) => html`<section id="team-home">
  ${until(dataPromise, html`<p>Loading &hellip;</p>`)}
</section>`;

const detailsTemplate = (
  team,
  members,
  requests,
  isOwner,
  isMember,
  onJoin,
  onLeave,
  isPending,
  onCancel,
  teamOwnerId,
  onRemove,
  onApprove,
  onDecline
) => html`<article class="layout">
  <img src="${team.logoUrl}" class="team-logo left-col" />
  <div class="tm-preview">
    <h2>${team.name}</h2>
    <p>${team.description}</p>
    <span class="details">${members.length} Members</span>
    <div>
      ${isOwner
        ? html`<a href="/edit/${team._id}" class="action">Edit team</a>`
        : nothing}
      ${isMember
        ? html`<a
            @click=${onLeave}
            href="javascript:void(0)"
            class="action invert"
            >Leave team</a
          >`
        : isPending
        ? nothing
        : html`<a @click=${onJoin} href="javascript:void(0)" class="action"
            >Join team</a
          >`}
      ${isPending
        ? html`Membership pending.
            <a @click=${onCancel} href="javascript:void(0)">Cancel request</a>`
        : nothing}
    </div>
  </div>
  ${members?.length > 0
    ? html`<div class="pad-large">
        <h3>Members</h3>
        <ul class="tm-members">
          ${members.map((m) =>
            memberTemplate(m, isOwner, teamOwnerId, onRemove)
          )}
        </ul>
      </div>`
    : nothing}
  ${requests?.length > 0
    ? html`<div class="pad-large">
    <h3>Membership Requests</h3>
    <ul class="tm-members">
      ${requests.map((m) => requestTemplate(m, isOwner, onApprove, onDecline))}
    </ul>
  </div>
</article>`
    : nothing}
</article>`;

const memberTemplate = (member, isOwner, teamOwnerId, onRemove) => html`
  <li>
    ${member.user.username}
    ${isOwner && !(teamOwnerId === member.user._id)
      ? html`<a
          @click=${onRemove.bind(null, member)}
          href="javascript:void(0)"
          class="tm-control action"
          >Remove from team</a
        >`
      : nothing}
  </li>
`;

const requestTemplate = (request, isOwner, onApprove, onDecline) => html`
  <li>
    ${request.user.username}
    ${isOwner
      ? html`<a
            @click=${onApprove.bind(null, request)}
            href="javascript:void(0)"
            class="tm-control action"
            >Approve</a
          ><a
            @click=${onDecline.bind(null, request)}
            href="javascript:void(0)"
            class="tm-control action"
            >Decline</a
          >`
      : nothing}
  </li>
`;

export function detailsView(ctx) {
  ctx.render(detailsLayout(loadTeam(ctx.params.teamId)));

  async function loadTeam(teamId) {
    const team = await dataService.getTeamById(teamId);
    const user = getUserData();

    const allTeamMembers = await dataService.getTeamMembers(teamId);

    const members = allTeamMembers.filter((m) => m.status === "member");
    const membershipRequests = allTeamMembers.filter(
      (m) => m.status === "pending"
    );

    console.log(allTeamMembers);

    const isOwner = team._ownerId === user._id;
    const isMember = allTeamMembers.some(
      (m) => m._ownerId === user._id && m.status === "member"
    );
    const isPending = allTeamMembers.some(
      (m) => m._ownerId === user._id && m.status === "pending"
    );

    return detailsTemplate(
      team,
      members,
      membershipRequests,
      isOwner,
      isMember,
      onJoin.bind(null, teamId),
      onLeave,
      isPending,
      onCancel,
      team._ownerId,
      onRemove,
      onApprove,
      onDecline
    );
    async function onDecline(request) {
      if (
        !confirm(
          `Are you sure you want to decline ${request.user.username}'s membership?`
        )
      ) {
        return;
      }

      dataService.deleteMember(request._id);

      ctx.page.redirect(`/details/${team._id}`);
    }

    async function onApprove(request) {
      if (
        !confirm(
          `Are you sure you want to approve ${request.user.username}'s membership?`
        )
      ) {
        return;
      }

      request.status = "member";

      dataService.editMember(request._id, request);

      ctx.page.redirect(`/details/${team._id}`);
    }

    async function onRemove(member) {
      if (
        !confirm(
          `Are you sure you want to remove ${member.user.username} from team?`
        )
      ) {
        return;
      }
      try {
        await dataService.deleteMember(member._id);
        ctx.page.redirect(`/details/${member.teamId}`);
      } catch (err) {
        alert(err.message);
        ctx.page.redirect("/");
      }
    }

    async function onLeave() {
      if (!confirm("Are you sure you want to leave this team ?")) {
        return;
      }

      const member = members.find((m) => m._ownerId === user._id);

      await dataService.deleteMember(member._id);
      ctx.page.redirect(`/details/${ctx.params.teamId}`);
    }

    async function onCancel() {
      if (!confirm("Are you sure you want to cancel request for this team ?")) {
        return;
      }

      const member = membershipRequests.find((m) => m._ownerId === user._id);

      await dataService.deleteMember(member._id);
      ctx.page.redirect(`/details/${ctx.params.teamId}`);
    }

    async function onJoin() {
      if (!confirm("Are you sure you want to join this team ?")) {
        return;
      }

      await dataService.memberRequest(ctx.params.teamId);
      ctx.page.redirect(`/details/${ctx.params.teamId}`);
    }
  }
}
