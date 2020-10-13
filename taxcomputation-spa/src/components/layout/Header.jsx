import React from "react";

const Header = ({ title }) => {
  return (
    <div
      className="p-d-flex p-jc-center p-flex-column"
      style={{
        background: "#fff",
        width: "100%",
        height: 66,
        paddingLeft: 20,
        borderLeft: "2px solid #f5f6f8",
        position: "fixed",
        zIndex: 1
      }}>
      <p style={{ marginTop: 5, marginBottom: 0, fontSize: 18, fontWeight: 600 }}>{title}</p>
    </div>
  );
};

export default Header;
