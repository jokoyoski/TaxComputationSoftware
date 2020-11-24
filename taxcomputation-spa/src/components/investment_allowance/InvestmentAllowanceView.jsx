import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const InvestmentAllowanceView = () => {
  const [investmentAllowanceData] = React.useState([
    {
      category: "Computers & Office Equipment",
      credit: "₦26,714,000.00"
    },
    {
      category: "Investment Allowance @ 10%",
      credit: "₦2,671,400.00"
    }
  ]);

  return (
    <DataTable
      className="p-datatable-gridlines"
      value={investmentAllowanceData}
      style={{ marginTop: 40 }}>
      <Column field="category" header="Additions to:"></Column>
      <Column field="credit" header="₦"></Column>
    </DataTable>
  );
};

export default InvestmentAllowanceView;
