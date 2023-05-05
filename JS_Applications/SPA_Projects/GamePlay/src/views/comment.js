import { html, nothing } from "../../node_modules/lit-html/lit-html.js";

export const commentsTemplate = (
  comments
) => html`<div class="details-comments">
<h2>Comments:</h2>
<ul>
  ${
    comments.length > 0
      ? comments.map((c) => commentTemplate(c))
      : html`<p class="no-comment">No comments.</p>`
  }
</div>`;

const commentTemplate = (comment) => html` <li class="comment">
  <p>${comment.comment}</p>
</li>`;

export const createCommentTemplate = (onSubmit) => html` <article
  class="create-comment"
>
  <label>Add new comment:</label>
  <form @submit=${onSubmit} class="form">
    <textarea name="comment" placeholder="Comment......"></textarea>
    <input class="btn submit" type="submit" value="Add Comment" />
  </form>
</article>`;
