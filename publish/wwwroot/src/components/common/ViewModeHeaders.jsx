import React from "react";

const ViewModeHeaders = ({ headers }) => {
  return (
    <>
      {headers.map((header, index) => (
        <p key={index} className="view-description">
          {header}
        </p>
      ))}
    </>
  );
};

export default ViewModeHeaders;
