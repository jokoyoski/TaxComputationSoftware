import React from "react";

const Loader = () => {
  return (
    <div className="p-d-flex p-flex-column p-jc-center p-ai-center" style={{ width: "100%" }}>
      <i className="pi pi-spin pi-spinner" style={{ fontSize: 24 }}></i>
    </div>
  );
};

export default Loader;
