import { Button } from "primereact/button";
import { Card } from "primereact/card";
import React from "react";
import Layout from "../components/layout";
import { Link } from "react-resource-router";
import constants from "../constants";

const NotFound = ({ isPage = true }) => {
  if (!isPage)
    return (
      <>
        <h1 style={{ margin: 0 }}>404 - Not Found</h1>
        <p>Sorry the page you are looking for doesn't exist.</p>
        <Link className="link" href={constants.routes.dashboard}>
          <Button label="Back to dashboard" icon="pi pi-arrow-left" />
        </Link>
      </>
    );

  return (
    <Layout title="">
      <Card style={{ width: "100%" }}>
        <h1 style={{ margin: 0 }}>404 - Not Found</h1>
        <p>Sorry the page you are looking for doesn't exist.</p>
        <Link className="link" href={constants.routes.dashboard}>
          <Button label="Back to dashboard" icon="pi pi-arrow-left" />
        </Link>
      </Card>
    </Layout>
  );
};

export default NotFound;
