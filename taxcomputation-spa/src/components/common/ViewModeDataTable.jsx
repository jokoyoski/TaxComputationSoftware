import React from "react";
import { DataTable } from "primereact/datatable";

const ViewModeDataTable = ({ value, width, children, scrollable = false }) => {
  return (
    <DataTable
      className="p-datatable-gridlines"
      value={value}
      style={{ marginTop: 40, width }}
      scrollable={scrollable}>
      {children}
    </DataTable>
  );
};

export default ViewModeDataTable;
