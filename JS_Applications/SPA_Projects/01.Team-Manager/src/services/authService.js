import * as request from "./request.js";
import * as userApi from "./util.js";

const endpoints = {
  login: "/users/login",
  register: "/users/register",
  logout: "/users/logout",
};

export const getUserData = userApi.getUserData;
export const setUserData = userApi.setUserData;
export const clearUserData = userApi.clearUserData;
export function isAuthenticated() {
  return Boolean(getUserData());
}

export async function login(email, password) {
  const user = await request.post(endpoints.login, { email, password });

  setUserData(user);
}

export async function register(data) {
  const user = await request.post(endpoints.register, data);

  setUserData(user);
}

export async function logout() {
  await request.get(endpoints.logout);
  clearUserData();
}
