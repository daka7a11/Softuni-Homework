const baseUrl = "http://localhost:3030/jsonstore/collections/books";

export async function getBooks() {
  return await (await fetch(baseUrl)).json();
}

export async function getBook(id) {
  return await (await fetch(`${baseUrl}/${id}`)).json();
}

export async function createBook(book) {
  return await (
    await fetch(baseUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(book),
    })
  ).json();
}

export async function editBook(id, book) {
  return await (
    await fetch(`${baseUrl}/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(book),
    })
  ).json();
}

export async function deleteBook(id) {
  return await (
    await fetch(`${baseUrl}/${id}`, {
      method: "DELETE",
    })
  ).json();
}
