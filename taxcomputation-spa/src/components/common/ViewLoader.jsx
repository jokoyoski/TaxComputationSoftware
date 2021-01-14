import React from "react";
import ReactDOM from "react-dom";
import Loader from "./Loader";

const ViewLoader = () => {
  return ReactDOM.createPortal(
    <Loader
      style={{
        position: "absolute",
        top: 0,
        bottom: 0,
        left: 0,
        right: 0,
        zIndex: 100,
        height: "100%",
        background: "rgba(255, 255, 255, 0.8)"
      }}
    />,
    document.querySelector("#view-container")
  );
};

export default ViewLoader;
