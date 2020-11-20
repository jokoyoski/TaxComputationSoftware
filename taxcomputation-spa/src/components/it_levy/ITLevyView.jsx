import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const ITLevyView = () => {
  const [itLevyData] = React.useState([
    {
      category: "Profit Before Taxation",
      credit: "₦502,563,000.00"
    },
    {
      category: "I.T. Levy @ 1% Thereon",
      credit: "₦5,025,630.00"
    }
  ]);

  return (
    <DataTable value={itLevyData} style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="credit" header="₦"></Column>
    </DataTable>
  );
};

export default ITLevyView;
