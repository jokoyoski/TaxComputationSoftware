import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const IncomeTaxView = () => {
  const [incomeTaxData] = React.useState([
    {
      category: "Profit Before Tax",
      debit: "",
      credit: "₦448,255,000.00"
    },
    {
      category: <strong>Add:Disallowable Expenses</strong>,
      debit: "",
      credit: ""
    },
    {
      category: "Depreciation",
      debit: "₦4,565,000.00",
      credit: ""
    },
    {
      category: "Foreign exchange loss",
      debit: "₦923,000.00",
      credit: ""
    },
    {
      category: "Loss allowance on trade receivable",
      debit: "₦44,723,000.00",
      credit: "₦67,928,000.00"
    }
  ]);

  return (
    <DataTable value={incomeTaxData} className="p-datatable-gridlines" style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="debit" header="₦"></Column>
      <Column field="credit" header="₦"></Column>
    </DataTable>
  );
};

export default IncomeTaxView;
