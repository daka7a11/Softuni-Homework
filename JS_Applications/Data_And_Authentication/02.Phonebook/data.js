const baseUrl = "http://localhost:3030/jsonstore/phonebook";

export async function loadDataAsync() {
  return await (await fetch(baseUrl)).json();
}

export async function addContactAsync(name, phone) {
  const contact = {
    person: name,
    phone: phone,
  };
  await fetch(baseUrl, {
    method: "POST",
    body: JSON.stringify(contact),
    headers: {
      "Content-Type": "application/json",
    },
  });
}

export async function deleteContactAsync(id) {
  fetch(baseUrl + "/" + id, {
    method: "DELETE",
  });
}
