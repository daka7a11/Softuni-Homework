import { html } from "./node_modules/lit-html/lit-html.js";

export function generateCard(contact) {
  return html`
    <div class="contact card">
      <div>
        <i class="far fa-user-circle gravatar"></i>
      </div>
      <div class="info">
        <h2>Name: ${contact.name}</h2>
        <button class="detailsBtn" @click=${detailsHandler}>Details</button>
        <div class="details" id=${contact.id}>
          <p>Phone number: ${contact.phoneNumber}</p>
          <p>Email: ${contact.email}</p>
        </div>
      </div>
    </div>
  `;

  function detailsHandler(e) {
    const detailsEl = e.target.parentElement.querySelector("div.details");

    if (detailsEl.style.display === "none" || detailsEl.style.display === "") {
      detailsEl.style.display = "block";
    } else {
      detailsEl.style.display = "none";
    }
  }
}
