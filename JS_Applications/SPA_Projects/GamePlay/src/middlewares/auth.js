import { getUserData } from "../api/util.js";

export function addUserToContext(ctx, next) {
  ctx.user = getUserData();
  next();
}
