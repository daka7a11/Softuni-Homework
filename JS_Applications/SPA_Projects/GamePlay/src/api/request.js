import { getUserData, clearUserData } from "./util.js";

const baseUrl = "http://localhost:3030";

async function request(method, url, data) {
  const options = {
    method,
    headers: {},
  };

  if (data != undefined) {
    options.headers["Content-Type"] = "application/json";
    options.body = JSON.stringify(data);
  }

  const user = getUserData();
  if (user) {
    const token = user.accessToken;
    options.headers["X-Authorization"] = token;
  }

  try {
    const res = await fetch(baseUrl + url, options);

    if (!res.ok) {
      const err = await res.json();

      if (res.status === 403) {
        const err403 = new Error(err.message);
        err403.status = 403;
        clearUserData();
        throw err403;
      }

      throw new Error(err.message);
    }

    if (res.status === 204) {
      return res;
    } else {
      return res.json();
    }
  } catch (err) {
    alert(err.message);
    throw new Error(err.message);
  }
}

const get = request.bind(null, "GET");
const post = request.bind(null, "POST");
const put = request.bind(null, "PUT");
const del = request.bind(null, "DELETE");

export { get, post, put, del as delete };
