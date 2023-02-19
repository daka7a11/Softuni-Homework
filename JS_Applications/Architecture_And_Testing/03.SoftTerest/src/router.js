let context, routes;

export function init(inputContext, links) {
  context = inputContext;
  routes = links;

  const router = {
    render,
  };
  return router;
}

function render(path, ...params) {
  routes[path](context, ...params);
}
