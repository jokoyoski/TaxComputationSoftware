import React from "react";
import "primereact/resources/themes/saga-blue/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.css";
import { Router, RouteComponent, createBrowserHistory } from "react-resource-router";
import { routes } from "./routes";

const history = createBrowserHistory();

function App() {
  return (
    <Router history={history} routes={routes}>
      <RouteComponent />
    </Router>
  );
}

export default App;
