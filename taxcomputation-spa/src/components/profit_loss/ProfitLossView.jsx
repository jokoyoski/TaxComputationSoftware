import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const ProfitLossView = () => {
  const [plData] = React.useState([
    {
      category: "Revenue",
      total: "₦584,132,000.00"
    },
    {
      category: "Other income",
      total: "₦36,656,000.00"
    },
    {
      category: "Other operating gain/loss",
      total: "(₦18,640,000.00)"
    },
    {
      category: "Adminitrative expenses",
      total: "(₦121,950,000.00)"
    },
    {
      category: "Profit/(Loss) before Tax",
      total: "₦448,255,000.00"
    }
  ]);

  return (
    <DataTable value={plData} style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="total" header="Total"></Column>
    </DataTable>
  );
};

export default ProfitLossView;
