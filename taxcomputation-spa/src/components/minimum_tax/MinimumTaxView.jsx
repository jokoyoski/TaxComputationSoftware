import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const MinimumTaxView = () => {
  const [minimumTaxData] = React.useState([
    {
      category: "0.5% OF TURNOVER",
      credit: "₦620,800,000.00"
    },
    {
      category: "Dividend Income",
      credit: ""
    },
    {
      category: <strong>Minimum Tax Payable</strong>,
      credit: "₦3,104,000.00"
    }
  ]);

  return (
    <DataTable className="p-datatable-gridlines" value={minimumTaxData} style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="credit" header="₦"></Column>
    </DataTable>
  );
};

export default MinimumTaxView;
