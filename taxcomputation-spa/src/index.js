import React from "react";
import ReactDOM from "react-dom";
import "fontsource-poppins";
import "./styles/index.css";
import App from "./App";
import { defaults } from "react-sweet-state";
import ErrorBoundary from "./components/common/ErrorBoundary";

// redux devtools
defaults.devtools = true;

ReactDOM.render(
  <React.StrictMode>
    <ErrorBoundary>
      <App />
    </ErrorBoundary>
  </React.StrictMode>,
  document.getElementById("root")
);
