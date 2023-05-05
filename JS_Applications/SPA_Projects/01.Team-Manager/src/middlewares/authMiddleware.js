import { getUserData, isAuthenticated } from "../services/authService.js";

export function authMiddleware(ctx, next) {
  const user = getUserData();
  ctx.isAuthenticated = isAuthenticated();
  ctx.user = user;
  next();
}
