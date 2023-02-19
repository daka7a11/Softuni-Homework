const homeEl = document.querySelector(".homePage");

let context = null;

export function renderHome(inputContext) {
  context = inputContext;
  context.updateNav();
  context.showView(homeEl);
}
