import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const IncomeTaxView = () => {
  const [incomeTaxData] = React.useState([
    {
      description: "Profit/Loss per accounts",
      col1: "",
      col2: "₦(48,765,894)"
    },
    {
      description: "",
      col1: "",
      col2: ""
    },
    {
      description: <strong>Add:Disallowable Expenses</strong>,
      col1: "",
      col2: ""
    },
    {
      description: "Depreciation",
      col1: "₦4,565,000.00",
      col2: ""
    },
    {
      description: "Foreign exchange loss",
      col1: "₦923,000.00",
      col2: ""
    },
    {
      description: "Loss allowance on trade receivable",
      col1: "₦44,723,000.00",
      col2: "₦67,928,000.00"
    }
  ]);

  return (
    <DataTable className="p-datatable-gridlines" value={incomeTaxData} style={{ marginTop: 40 }}>
      <Column field="description" header=""></Column>
      <Column field="col1" header="₦"></Column>
      <Column field="col2" header="₦"></Column>
    </DataTable>
  );
};

export default IncomeTaxView;
