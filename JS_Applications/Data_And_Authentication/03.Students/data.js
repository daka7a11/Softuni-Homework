const baseUrl = "http://localhost:3030/jsonstore/collections/students";

export async function createStudent(student) {
  await fetch(baseUrl, {
    method: "POST",
    body: JSON.stringify(student),
    headers: {
      "Content-Type": "application/json",
    },
  });
}

export async function getStudents() {
  return await (await fetch(baseUrl)).json();
}
