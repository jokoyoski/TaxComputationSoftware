import React from "react";
import { Redirect } from "react-resource-router";

const Home = () => {
  return <Redirect to="/login" />;
};

export default Home;
