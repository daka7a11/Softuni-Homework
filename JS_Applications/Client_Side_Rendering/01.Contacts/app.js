import { render } from "./node_modules/lit-html/lit-html.js";
import { generateCard } from "./cardTemplate.js";
import { contacts } from "./contacts.js";

const contactsEl = document.querySelector("#contacts");

const cards = contacts.map((contact) => generateCard(contact));
render(cards, contactsEl);
