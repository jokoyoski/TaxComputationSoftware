import React from "react";
import Layout from "../layout";

const Loader = ({ title }) => {
  return (
    <Layout title={title} loading={true}>
      <div
        className="p-d-flex p-flex-column p-jc-center p-ai-center"
        style={{ height: "calc(100vh - 120px)" }}>
        <i className="pi pi-spin pi-spinner" style={{ fontSize: 24 }}></i>
        <p>Loading data...</p>
      </div>
    </Layout>
  );
};

export default Loader;
