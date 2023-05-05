import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import {
  getById,
  deleteGame,
  getComments,
  createComment,
} from "../api/data.js";
import { commentsTemplate, createCommentTemplate } from "./comment.js";

const detailsTemplate = (
  game,
  isOwner,
  onDelete,
  comments,
  onSubmitComment,
  isUser
) => html`
  <section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">
      <div class="game-header">
        <img class="game-img" src="${game.imageUrl}" />
        <h1>${game.title}</h1>
        <span class="levels">MaxLevel: ${game.maxLevel}</span>
        <p class="type">${game.category}</p>
      </div>

      <p class="text">${game.summary}</p>

      ${commentsTemplate(comments)}
      ${isOwner
        ? html`<div class="buttons">
            <a href="/edit/${game._id}" class="button">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="button"
              >Delete</a
            >
          </div>`
        : nothing}
    </div>

    <!-- CREATE NEW COMMENT -->
    ${!isOwner
      ? isUser
        ? createCommentTemplate(onSubmitComment)
        : nothing
      : nothing}
  </section>
`;

export async function detailsPage(ctx) {
  const gameId = ctx.params.id;
  const game = await getById(gameId);
  const isOwner = game._ownerId === ctx.user?._id;
  const isUser = Boolean(ctx.user);

  const comments = await getComments(ctx.params.id);

  ctx.render(
    detailsTemplate(game, isOwner, onDelete, comments, onSubmitComment, isUser)
  );

  async function onDelete(e) {
    e.preventDefault();

    if (confirm(`Are you sure you want to delete ${game.title}?`)) {
      await deleteGame(gameId);
      ctx.page.redirect("/");
    }
  }

  async function onSubmitComment(e) {
    e.preventDefault();

    const { comment } = Object.fromEntries(new FormData(e.target));

    if (comment === "") {
      alert("You can't add empty comment!");
      return;
    }

    await createComment({ gameId, comment });

    ctx.page.redirect(`/details/${gameId}`);
  }
}
