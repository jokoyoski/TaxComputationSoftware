import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const CapitalAllowanceView = ({ year }) => {
  const [balancingAllowanceData] = React.useState([
    {
      category: <strong>Motor Vehicles</strong>,
      credit: "",
      balancingAllowance: "",
      balancingCharge: "",
      cost: "",
      salesProceed: "",
      twdv: ""
    },
    {
      category: "Cost up to 2018 YOA",
      credit: "₦14,694,750.00",
      balancingAllowance: "",
      balancingCharge: "",
      cost: "₦14,694,750.00",
      salesProceed: "",
      twdv: ""
    },
    {
      category: "Initial Allowance",
      credit: "₦7,347,375.00",
      balancingAllowance: "",
      balancingCharge: "",
      cost: "",
      salesProceed: "",
      twdv: ""
    },
    {
      category: "Annual allowances up to 2019",
      credit: "₦3,673,688.00",
      balancingAllowance: "",
      balancingCharge: "",
      cost: "",
      salesProceed: "",
      twdv: ""
    },
    {
      category: "Residue at 31.12.2019",
      credit: "₦3,673,688.00",
      balancingAllowance: "",
      balancingCharge: "",
      cost: "",
      salesProceed: "",
      twdv: "₦3,673,688.00"
    },
    {
      category: "Sales Proceeds",
      credit: "₦5,510,531.00",
      balancingAllowance: "",
      balancingCharge: "",
      cost: "",
      salesProceed: "₦5,510,531.00",
      twdv: ""
    },
    {
      category: "Balancing charge",
      credit: "₦1,836,844.00",
      balancingAllowance: "",
      balancingCharge: "₦1,836,844.00",
      cost: "",
      salesProceed: "",
      twdv: ""
    }
  ]);

  return (
    <DataTable
      value={balancingAllowanceData}
      className="p-datatable-gridlines"
      style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="credit" header="₦"></Column>
      <Column field="balancingAllowance" header="Balancing Allowance (₦)"></Column>
      <Column field="balancingCharge" header="Balancing Charge (₦)"></Column>
      <Column field="cost" header="Cost (₦)"></Column>
      <Column field="salesProceed" header="Sales Proceed (₦)"></Column>
      <Column field="twdv" header="TWDV"></Column>
    </DataTable>
  );
};

export default CapitalAllowanceView;
