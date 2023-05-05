import * as api from "./api.js";

const endpoints = {
  recent: "/data/games?sortBy=_createdOn%20desc&distinct=category",
  getAll: "/data/games?sortBy=_createdOn%20desc",
  create: "/data/games",
  getById: "/data/games/",
  deleteGame: "/data/games/",
  editGame: "/data/games/",
  getComments: (gameId) => `/data/comments?where=gameId%3D%22${gameId}%22`,
  createComment: "/data/comments",
};

export async function recentGames() {
  return await api.get(endpoints.recent);
}

export async function getAll() {
  return await api.get(endpoints.getAll);
}

export async function createGame(game) {
  return await api.post(endpoints.create, game);
}

export async function getById(id) {
  return await api.get(endpoints.getById + id);
}

export async function deleteGame(id) {
  return await api.del(endpoints.deleteGame + id);
}

export async function editGame(id, game) {
  return await api.put(endpoints.editGame + id, game);
}

export async function getComments(gameId) {
  return await api.get(endpoints.getComments(gameId));
}

export async function createComment(data) {
  return await api.post(endpoints.createComment, data);
}
