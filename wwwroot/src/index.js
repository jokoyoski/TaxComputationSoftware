import React from "react";
import ReactDOM from "react-dom";
import "fontsource-poppins";
import "./styles/index.css";
import App from "./App";
import { defaults } from "react-sweet-state";

// redux devtools
defaults.devtools = true;

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById("root")
);
