import { Button } from "primereact/button";
import React from "react";
import constants from "../../constants";
import Layout from "../layout";

const Error = ({ title, error, refresh }) => {
  return (
    <Layout title={title}>
      <div
        className="p-d-flex p-flex-column p-jc-center p-ai-center"
        style={{ height: "calc(100vh - 120px)" }}>
        <Button
          icon="pi pi-refresh pi-24"
          className="p-button-rounded p-button-text"
          onClick={refresh}
        />
        <div style={{ width: 400, textAlign: "center" }}>
          {error.response ? (
            error.response.data.errors.error.map(error => <p>{error}</p>)
          ) : error.message === "Network Error" ? (
            <p>{constants.networkErrorMessage}</p>
          ) : (
            <p>{error.message}</p>
          )}
        </div>
      </div>
    </Layout>
  );
};

export default Error;
