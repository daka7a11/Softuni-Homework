import * as request from "./request.js";

const endpoints = {
  register: "/users/register",
  login: "/users/login",
  logout: "/users/logout",
  ideas: "/data/ideas",
};

export async function getIdeas() {
  return request.get(endpoints.ideas);
}

export async function getIdeaById(id) {
  return request.get(endpoints.ideas + "/" + id);
}

export async function login(user) {
  return request.post(endpoints.login, user);
}

export async function logout() {
  const res = await request.get(endpoints.logout);
  const user = JSON.parse(sessionStorage.getItem("user"));
  if (!user) {
    return;
  }
  alert(`Bye ${user.email}.`);
  sessionStorage.removeItem("user");
}

export async function createIdea(idea) {
  return request.post(endpoints.ideas, idea);
}

export async function deleteIdea(id) {
  return request.delete(endpoints.ideas + "/" + id);
}

export async function register(data) {
  return request.post(endpoints.register, data);
}
