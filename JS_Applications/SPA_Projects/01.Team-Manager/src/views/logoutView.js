import * as authService from "../services/authService.js";

export async function logoutView(ctx) {
  await authService.logout();

  ctx.page.redirect("/");
}
