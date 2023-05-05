import page from "../node_modules/page/page.mjs";
import { authMiddleware } from "./middlewares/authMiddleware.js";
import { renderMiddleware } from "./middlewares/renderMiddleware.js";
import { createView } from "./views/create.js";
import { detailsView } from "./views/details.js";
import { editView } from "./views/edit.js";
import { homeView } from "./views/homeView.js";
import { loginView } from "./views/loginView.js";
import { logoutView } from "./views/logoutView.js";
import { registerView } from "./views/registerView.js";
import { teamsView } from "./views/teams.js";

page(authMiddleware);
page(renderMiddleware);

page("/", homeView);
page("/login", loginView);
page("/register", registerView);
page("/logout", logoutView);
page("/teams", teamsView);
page("/create", createView);
page("/details/:teamId", detailsView);
page("/edit/:teamId", editView);

page.start();
