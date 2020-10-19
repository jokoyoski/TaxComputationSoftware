import React from "react";
import "primereact/resources/themes/saga-blue/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.css";
import { Router, RouteComponent, createBrowserHistory } from "react-resource-router";
import { routes } from "./routes";
import { useAuth } from "./store/AuthStore";
import utils from "./utils";
import { useCompany } from "./store/CompanyStore";

const history = createBrowserHistory();

function App() {
  const [auth, { initAuth }] = useAuth();
  const [company, { initCompany }] = useCompany();

  window.onbeforeunload = () => {
    utils.saveState(auth, "auth");
    utils.saveState(company, "company");
    sessionStorage.setItem("path", history.location.pathname);
  };

  window.onload = () => {
    initAuth(utils.loadState("auth"));
    initCompany(utils.loadState("company"));
  };

  return (
    <Router history={history} routes={routes}>
      <RouteComponent />
    </Router>
  );
}

export default App;
