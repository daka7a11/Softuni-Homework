const userEl = document.getElementById("user");
const guestEl = document.getElementById("guest");
const catalogPageEl = document.querySelector("#catalogPage");

export function updateNavigation() {
  if (sessionStorage.getItem("authToken") != null) {
    userEl.style.display = "inline-block";
    guestEl.style.display = "none";
  } else {
    guestEl.style.display = "inline-block";
    userEl.style.display = "none";
  }
}

export async function login(data) {
  const body = JSON.stringify({
    email: data.email,
    password: data.password,
  });

  try {
    const response = await fetch("http://localhost:3030/users/login", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
      },
      body,
    });
    const data = await response.json();
    if (response.status == 200) {
      console.log(data);
      sessionStorage.setItem("authToken", data.accessToken);
      sessionStorage.setItem("email", data.email);
      sessionStorage.setItem("userId", data._id);
      alert(`Hello ${data.email}`);
      catalogPageEl.click();
    } else {
      throw new Error(data.message);
    }
  } catch (err) {
    alert(err.message);
    console.error(err.message);
  }
}

export async function logout() {
  alert(`Bye ${sessionStorage.getItem("email")}!`);
  sessionStorage.clear();
  catalogPageEl.click();
}
