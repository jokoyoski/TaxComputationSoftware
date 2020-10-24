import React from "react";
import Header from "./Header";
import Sidebar from "./Sidebar";

const Layout = ({ title, children }) => {
  return (
    <div className="p-d-flex">
      <Sidebar selectedTitle={title} />
      <div className="p-d-flex p-flex-column" style={{ width: "100%", marginLeft: 256 }}>
        <Header title={title} />
        <div style={{ padding: 20, marginTop: 66 }}>{children}</div>
      </div>
    </div>
  );
};

export default Layout;
