function attachEvents() {
  const baseUrl = "http://localhost:3030/jsonstore/blog";

  const loadPostsBtn = document.getElementById("btnLoadPosts");
  loadPostsBtn.addEventListener("click", loadPostsTitles);
  const postsSelect = document.getElementById("posts");
  const viewBtn = document.getElementById("btnViewPost");
  viewBtn.addEventListener("click", renderPosts);

  const postTitleEl = document.getElementById("post-title");
  const postBodyEl = document.getElementById("post-body");
  const postCommentsUl = document.getElementById("post-comments");

  function loadPostsTitles(e) {
    e.preventDefault();

    fetch(baseUrl + "/posts")
      .then((response) => response.json())
      .then((data) => renderTitles(data));

    function renderTitles(data) {
      postsSelect.innerHTML = "";
      const defaultOption = document.createElement("option");
      defaultOption.value = "";
      defaultOption.text = "Select a post";
      defaultOption.selected = true;
      defaultOption.disabled = true;
      postsSelect.appendChild(defaultOption);

      Object.keys(data).forEach((key) => {
        const option = document.createElement("option");
        option.textContent = data[key].title;
        option.value = key;
        postsSelect.appendChild(option);
      });
    }
  }

  function renderPosts(e) {
    e.preventDefault();

    const selectedPostId = postsSelect.value;
    let selectedPostTitle = "";
    let selectedPostBody = "";

    fetch(baseUrl + "/posts/" + selectedPostId)
      .then((response) => response.json())
      .then((data) => {
        selectedPostTitle = data.title;
        selectedPostBody = data.body;
      });

    const currPostComments = [];

    fetch(baseUrl + "/comments")
      .then((response) => response.json())
      .then((data) => {
        postCommentsUl.innerHTML = "";
        Object.keys(data).forEach((key) => {
          if (data[key].postId === selectedPostId) {
            currPostComments.push(data[key]);
          }
        });
        postTitleEl.textContent = selectedPostTitle;
        postBodyEl.textContent = selectedPostBody;

        currPostComments.forEach((comment) => {
          const li = document.createElement("li");
          li.textContent = comment.text;
          postCommentsUl.appendChild(li);
        });
      });
  }
}

attachEvents();
