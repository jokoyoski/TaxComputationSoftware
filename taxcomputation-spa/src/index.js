import React from "react";
import ReactDOM from "react-dom";
import "fontsource-poppins";
import "./index.css";
import App from "./App";
import axiosConfig from "./configs/axios.config";
import { defaults } from "react-sweet-state";

// redux devtools
defaults.devtools = true;

// axios config
axiosConfig();

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById("root")
);
