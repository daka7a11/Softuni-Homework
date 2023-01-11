function getInfo() {
  const validIds = ["1287", "1308", "1327", "2334"];
  const baseUrl = "http://localhost:3030/jsonstore/bus/businfo/";

  const inputIdEl = document.getElementById("stopId");

  const stopNameEl = document.getElementById("stopName");
  const busesEl = document.getElementById("buses");

  inputIdEl.textContent = "";
  busesEl.textContent = "";

  if (!validIds.some((x) => x === inputIdEl.value)) {
    stopNameEl.textContent = "Error";
    return;
  }

  fetch(baseUrl + inputIdEl.value)
    .then((response) => response.json())
    .then((result) => showBuses(result));

  function showBuses(busInfo) {
    stopNameEl.textContent = busInfo.name;
    Object.entries(busInfo.buses).forEach((bus) => {
      const [key, value] = bus;
      const li = document.createElement("li");
      li.textContent = `Bus ${key} arrives in ${value}`;
      busesEl.appendChild(li);
    });
  }
}
