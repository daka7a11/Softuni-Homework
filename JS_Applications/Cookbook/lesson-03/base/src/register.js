const baseUrl = "http://localhost:3030/";
const endPoint = "users/register";

const form = document.querySelector("form");

form.addEventListener("submit", register);

async function register(e) {
  e.preventDefault();

  const formData = new FormData(form);

  const email = formData.get("email");
  const password = formData.get("password");
  const rePass = formData.get("rePass");

  if (password != rePass) {
    alert("The passwords do not match!");
    return;
  }

  const data = {
    email,
    password,
  };

  fetch(baseUrl + endPoint, {
    method: "POST",
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify(data),
  })
    .then((res) => res.json())
    .then((data) => {
      sessionStorage.setItem("email", data.email);
      sessionStorage.setItem("id", data._id);
      sessionStorage.setItem("accessToken", data.accessToken);

      console.log(data);

      alert(
        `Register is successfully. Now you are logged with ${data.username}`
      );

      location.href = "/Cookbook/lesson-03/base/index.html";
    });
}
