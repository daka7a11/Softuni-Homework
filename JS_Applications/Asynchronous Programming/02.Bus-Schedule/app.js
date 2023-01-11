function solve() {
  const baseUrl = "http://localhost:3030/jsonstore/bus/schedule/";
  const infoEl = document.getElementById("info");
  const departBtn = document.getElementById("depart");
  const arriverBtn = document.getElementById("arrive");
  let stopId = "depot";
  let currStopName = "";

  function depart() {
    departBtn.disabled = true;
    arriverBtn.disabled = false;

    fetch(baseUrl + stopId)
      .then((response) => response.json())
      .then((response) => {
        currStopName = response.name;
        infoEl.textContent = `Next stop ${currStopName}`;
        stopId = response.next;
      });
  }

  function arrive() {
    departBtn.disabled = false;
    arriverBtn.disabled = true;

    infoEl.textContent = `Arriving at ${currStopName}`;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
