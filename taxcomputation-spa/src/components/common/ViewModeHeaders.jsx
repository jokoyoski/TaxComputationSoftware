import React from "react";

const ViewModeHeaders = ({ headers }) => {
  return (
    <>
      {headers.map(header => (
        <p className="view-description">{header}</p>
      ))}
    </>
  );
};

export default ViewModeHeaders;
