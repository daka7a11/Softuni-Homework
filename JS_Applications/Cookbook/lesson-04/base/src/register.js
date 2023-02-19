const catalogPageEl = document.querySelector("#catalogPage");

const regEl = document.querySelector("#register");
const form = regEl.querySelector("form");

form.addEventListener("submit", (ev) => {
  ev.preventDefault();
  const formData = new FormData(ev.target);
  onSubmit(
    [...formData.entries()].reduce(
      (p, [k, v]) => Object.assign(p, { [k]: v }),
      {}
    )
  );
});

export function renderRegister() {
  regEl.style.display = "block";
}

async function onSubmit(data) {
  if (data.password != data.rePass) {
    return console.error("Passwords don't match");
  }

  const body = JSON.stringify({
    email: data.email,
    password: data.password,
  });

  try {
    const response = await fetch("http://localhost:3030/users/register", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
      },
      body,
    });
    const data = await response.json();
    if (response.status == 200) {
      sessionStorage.setItem("authToken", data.accessToken);
      sessionStorage.setItem("email", data.email);
      sessionStorage.setItem("userId", data._id);
      alert(`Hello ${data.email}`);
      catalogPageEl.click();
    } else {
      throw new Error(data.message);
    }
  } catch (err) {
    console.error(err.message);
  }
}
