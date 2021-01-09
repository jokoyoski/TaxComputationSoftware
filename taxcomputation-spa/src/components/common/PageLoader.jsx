import React from "react";
import Layout from "../layout";

const PageLoader = ({ title, activeSidebar = true }) => {
  return (
    <Layout title={title} loading={true} activeSidebar={activeSidebar}>
      <div
        className="p-d-flex p-flex-column p-jc-center p-ai-center"
        style={{ height: "calc(100vh - 120px)" }}>
        <i className="pi pi-spin pi-spinner" style={{ fontSize: 24 }}></i>
        <p>Loading data...</p>
      </div>
    </Layout>
  );
};

export default PageLoader;
