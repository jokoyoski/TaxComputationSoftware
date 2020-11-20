import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const DeferredTaxView = () => {
  const [deferredTaxData] = React.useState([
    {
      category: "Net Book Value of Fixed Assets as at 31.12.19",
      debit: "",
      credit: "₦10,633,000.00"
    },
    {
      category: "Less:",
      debit: "",
      credit: ""
    },
    {
      category: "Tax Written Down Value as at 31.12.19",
      debit: "(₦2,932,845,440.00)",
      credit: ""
    },
    {
      category: "Unabsorbed Capital Allowance",
      debit: "(₦561,061,694.00)",
      credit: ""
    },
    {
      category: "Impairment on Receivables",
      debit: "₦44,723,000.00",
      credit: "(₦3,449,184,134.00)"
    }
  ]);

  return (
    <DataTable value={deferredTaxData} style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="debit" header="₦"></Column>
      <Column field="credit" header="₦"></Column>
    </DataTable>
  );
};

export default DeferredTaxView;
