import React from "react";
import "primereact/resources/themes/saga-blue/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.css";
import { Router, RouteComponent, createBrowserHistory } from "react-resource-router";
import { routes } from "./routes";
import { useAuth } from "./store/AuthStore";
import utils from "./utils";

const history = createBrowserHistory();

function App() {
  const [state, { initAuth }] = useAuth();

  window.onbeforeunload = () => {
    utils.saveState(state);
    sessionStorage.setItem("path", history.location.pathname);
  };

  window.onload = () => {
    initAuth(utils.loadState());
  };

  return (
    <Router history={history} routes={routes}>
      <RouteComponent />
    </Router>
  );
}

export default App;
