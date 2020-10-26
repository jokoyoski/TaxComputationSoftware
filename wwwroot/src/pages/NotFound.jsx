import { Card } from "primereact/card";
import React from "react";
import Layout from "../components/layout";

const NotFound = () => {
  return (
    <Layout title="">
      <Card style={{ width: "100%" }}>
        <h1 style={{ margin: 0 }}>404 - Not Found</h1>
        <p>Sorry the page you are looking for doesn't exist.</p>
      </Card>
    </Layout>
  );
};

export default NotFound;
