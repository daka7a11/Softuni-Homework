const baseUrl = "http://localhost:3030/";
const endPoint = "users/login";

const form = document.querySelector("form");

form.addEventListener("submit", login);

function login(e) {
  e.preventDefault();
  const formData = new FormData(form);

  const email = formData.get("email");
  const password = formData.get("password");

  fetch(baseUrl + endPoint, {
    method: "POST",
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify({ email, password }),
  })
    .then((res) => {
      return res.json();
    })
    .then((data) => {
      if (data.code) {
        alert(data.message);
        return;
      }

      sessionStorage.setItem("email", data.email);
      sessionStorage.setItem("id", data._id);
      sessionStorage.setItem("accessToken", data.accessToken);

      alert(`Successfully logged with ${data.email}`);

      location.href = "/Cookbook/lesson-03/base/index.html";
    });
}
