function attachEvents() {
  const baseUrl = "http://localhost:3030/jsonstore/messenger";
  const authorEl = document.querySelector('input[name="author"]');
  const messageEl = document.querySelector('input[name="content"]');
  const sendBtn = document.querySelector("#submit");
  const refreshBtn = document.querySelector("#refresh");
  const messagesEl = document.querySelector("#messages");

  sendBtn.addEventListener("click", sendMessage);
  refreshBtn.addEventListener("click", refreshMessages);

  function sendMessage(e) {
    e.preventDefault();

    const message = {
      author: authorEl.value,
      content: messageEl.value,
    };

    fetch(baseUrl, {
      method: "POST",
      body: JSON.stringify(message),
      headers: {
        "Content-Type": "application/json",
      },
    });

    authorEl.value = "";
    messageEl.value = "";
  }
  function refreshMessages(e) {
    e.preventDefault();

    fetch(baseUrl)
      .then((response) => response.json())
      .then((data) => {
        messagesEl.value = "";
        Object.entries(data).forEach(([k, v]) => {
          messagesEl.value += `${v.author}: ${v.content}\n`;
        });
      });
  }
}
attachEvents();
