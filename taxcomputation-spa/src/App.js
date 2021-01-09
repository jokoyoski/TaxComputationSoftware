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
import axiosConfig from "./configs/axios.config";
import { useResources } from "./store/ResourcesStore";

const history = createBrowserHistory();

function App() {
  const [auth, { initAuth }] = useAuth();
  const [company, { initCompany }] = useCompany();
  const [resource, { initResource }] = useResources();

  window.onbeforeunload = () => {
    utils.saveState(auth, "auth");
    utils.saveState(company, "company");
    utils.saveState(resource, "resource");
    sessionStorage.setItem("path", history.location.pathname);
    sessionStorage.setItem("token", auth.token);
  };

  window.onload = () => {
    initAuth(utils.loadState("auth"));
    initCompany(utils.loadState("company"));
    initResource(utils.loadState("resource"));
    sessionStorage.removeItem("token");
  };

  // axios config
  axiosConfig(auth.token);

  return (
    <Router history={history} routes={routes}>
      <RouteComponent />
    </Router>
  );
}

export default App;
