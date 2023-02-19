import { router } from "./router.js";

router("/");

const navBar = document.querySelector("nav");
navBar.addEventListener("click", (e) => {
  e.preventDefault();

  if (e.target.tagName === "A") {
    const url = new URL(e.target.href);

    const pathname = url.pathname.split("/").pop();

    router(pathname || "/");
  }
});
