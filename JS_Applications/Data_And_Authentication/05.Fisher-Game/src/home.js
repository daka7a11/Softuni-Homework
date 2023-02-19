const url = "http://localhost:3030/data/catches";

const mainEl = document.querySelector("main");
const homeViewEl = document.getElementById("home-view");
const catchesDivEl = document.getElementById("catches");

const loadCatchesBtn = document.querySelector("aside button");
loadCatchesBtn.addEventListener("click", loadCatches);

export function renderHomePage() {
  mainEl.innerHTML = "";
  mainEl.appendChild(homeViewEl);
}

export function loadCatches(e) {
  e.preventDefault();

  catchesDivEl.innerHTML = "";

  fetch(url)
    .then((res) => res.json())
    .then((data) => {
      data.forEach((x) => {
        const catchDiv = createCatchEl(x);
        catchesDivEl.appendChild(catchDiv);
      });

      const chachesBtns = [...document.querySelectorAll("button")].filter((x) =>
        x.hasAttribute("data-id")
      );

      chachesBtns.forEach((btn) => {
        const currOwnerId = btn.parentElement.id;

        const ownerId = sessionStorage.getItem("ownerId");

        if (!(ownerId && ownerId === currOwnerId)) {
          btn.disabled = true;
        }
      });
    });
}

function createCatchEl(data) {
  const mainDiv = document.createElement("div");
  mainDiv.setAttribute("class", "catch");

  const anglerLbl = document.createElement("label");
  anglerLbl.textContent = "Angler";
  const anglerInput = document.createElement("input");
  anglerInput.type = "text";
  anglerInput.setAttribute("class", "angler");
  anglerInput.value = data.angler;

  const weightLbl = document.createElement("label");
  weightLbl.textContent = "Weight";
  const weightInput = document.createElement("input");
  weightInput.type = "text";
  weightInput.setAttribute("class", "weight");
  weightInput.value = data.weight;

  const speciesLbl = document.createElement("label");
  speciesLbl.textContent = "Species";
  const speciesInput = document.createElement("input");
  speciesInput.type = "text";
  speciesInput.setAttribute("class", "species");
  speciesInput.value = data.species;

  const locationLbl = document.createElement("label");
  locationLbl.textContent = "Location";
  const locationInput = document.createElement("input");
  locationInput.type = "text";
  locationInput.setAttribute("class", "location");
  locationInput.value = data.location;

  const baitLbl = document.createElement("label");
  baitLbl.textContent = "Bait";
  const baitInput = document.createElement("input");
  baitInput.type = "text";
  baitInput.setAttribute("class", "bait");
  baitInput.value = data.bait;

  const captureTimeLbl = document.createElement("label");
  captureTimeLbl.textContent = "Capture Time";
  const captureTimeInput = document.createElement("input");
  captureTimeInput.type = "number";
  captureTimeInput.setAttribute("class", "captureTime");
  captureTimeInput.value = data.captureTime;

  const updateBtn = document.createElement("button");
  updateBtn.textContent = "Update";
  updateBtn.setAttribute("class", "update");
  updateBtn.setAttribute("data-id", data._id);

  const deleteBtn = document.createElement("button");
  deleteBtn.textContent = "Delete";
  deleteBtn.setAttribute("class", "delete");
  deleteBtn.setAttribute("data-id", data._id);

  const btnsDiv = document.createElement("div");
  btnsDiv.setAttribute("id", data._ownerId);
  btnsDiv.appendChild(updateBtn);
  btnsDiv.appendChild(deleteBtn);

  mainDiv.appendChild(anglerLbl);
  mainDiv.appendChild(anglerInput);
  mainDiv.appendChild(weightLbl);
  mainDiv.appendChild(weightInput);
  mainDiv.appendChild(speciesLbl);
  mainDiv.appendChild(speciesInput);
  mainDiv.appendChild(locationLbl);
  mainDiv.appendChild(locationInput);
  mainDiv.appendChild(baitLbl);
  mainDiv.appendChild(baitInput);
  mainDiv.appendChild(captureTimeLbl);
  mainDiv.appendChild(captureTimeInput);
  mainDiv.appendChild(btnsDiv);

  return mainDiv;
}
