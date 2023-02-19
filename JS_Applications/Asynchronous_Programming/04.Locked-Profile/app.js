function lockedProfile() {
  const url = "http://localhost:3030/jsonstore/advanced/profiles";
  const mainEl = document.getElementById("main");
  let userCounter = 1;

  fetch(url)
    .then((response) => response.json())
    .then((data) => showProfiles(data));

  function showProfiles(profilesData) {
    mainEl.textContent = "";
    const objKeys = Object.keys(profilesData);
    objKeys.forEach((key) => {
      const profile = profilesData[key];
      const profileEl = createProfile(profile);
      mainEl.appendChild(profileEl);
    });
  }

  function createProfile(profile) {
    const mainDiv = createElement("div", "", ["profile"]);

    const profileImg = createElement("img", "", ["userIcon"], mainDiv);
    profileImg.src = "./iconProfile2.png";

    const lockLbl = createElement("label", "Lock", null, mainDiv);
    const inputLockEl = createElement("input", "", null, mainDiv);
    inputLockEl.type = "radio";
    inputLockEl.name = "user" + userCounter + "Locked";
    inputLockEl.value = "lock";
    inputLockEl.checked = true;

    const unlockLbl = createElement("label", "Unlock", null, mainDiv);
    const inputUnlockEl = createElement("input", "", null, mainDiv);
    inputUnlockEl.type = "radio";
    inputUnlockEl.name = "user" + userCounter + "Locked";
    inputUnlockEl.value = "unlock";
    inputUnlockEl.checked = false;

    const br = createElement("br", "", null, mainDiv);
    const hr = createElement("hr", "", null, mainDiv);

    const usernameLbl = createElement("label", "Username", null, mainDiv);

    const inputUsernameEl = createElement("input", "", null, mainDiv);
    inputUsernameEl.type = "text";
    inputUsernameEl.name = "user" + userCounter + "Username";
    inputUsernameEl.value = profile.username;
    inputUsernameEl.disabled = true;
    inputUsernameEl.readOnly = true;

    const usernameDiv = createElement(
      "div",
      "",
      [`user${userCounter}Username`],
      mainDiv
    );

    usernameDiv.style.display = "none";

    usernameDiv.appendChild(hr);

    const emailLbl = createElement("label", "Email:", null, usernameDiv);

    const inputEmailEl = createElement("input", "", null, usernameDiv);
    inputEmailEl.type = "email";
    inputEmailEl.name = "user" + userCounter + "Email";
    inputEmailEl.value = profile.email;
    inputEmailEl.disabled = true;
    inputEmailEl.readOnly = true;

    const ageLbl = createElement("label", "Age:", null, usernameDiv);
    const inputAgeEl = createElement("input", "", null, usernameDiv);
    inputAgeEl.type = "text";
    inputAgeEl.name = "user" + userCounter + "Age";
    inputAgeEl.value = profile.age;
    inputAgeEl.disabled = true;
    inputAgeEl.readOnly = true;

    const showBtn = createElement("button", "Show more", null, mainDiv);
    showBtn.addEventListener("click", onClick);

    userCounter++;

    return mainDiv;
  }

  function onClick(e) {
    e.preventDefault();

    const lockEl = e.target.parentElement.querySelector('input[value="lock"]');
    if (lockEl.checked) {
      return;
    }

    const profileDiv = e.target.parentElement.querySelector(
      'div[class$="Username"]'
    );
    if (e.target.textContent === "Show more") {
      profileDiv.style.display = "block";
      e.target.textContent = "Hide";
    } else {
      profileDiv.style.display = "none";
      e.target.textContent = "Show more";
    }
  }

  function createElement(tag, context, clases, parent) {
    clases = clases || [];
    const el = document.createElement(tag);
    el.textContent = context;

    clases.forEach((x) => {
      el.classList.add(x);
    });

    if (parent) {
      parent.appendChild(el);
    }
    return el;
  }
}
