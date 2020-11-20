import React from "react";
import { Dropdown } from "primereact/dropdown";
import { Button } from "primereact/button";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const MappingMode = ({ year, setYear, yearSelectItems }) => {
  const [item, setItem] = React.useState();
  const [selectedAccounts, setSelectedAccounts] = React.useState();
  const [allAccount] = React.useState([
    {
      accountDescription: "Petty Cash",
      debitAmount: "₦52,154.07",
      creditAmount: "₦0.00"
    },
    {
      accountDescription: "Inventory",
      debitAmount: "₦20,000.00",
      creditAmount: "₦0.00"
    },
    {
      accountDescription: "Plant & Machinery",
      debitAmount: "₦3,966,900.64",
      creditAmount: "₦0.00"
    },
    {
      accountDescription: "Furniture & Fittings",
      debitAmount: "₦12,252,961.97",
      creditAmount: "₦0.00"
    },
    {
      accountDescription: "Branch Cash Movement",
      debitAmount: "₦0.00",
      creditAmount: "₦349.03"
    }
  ]);
  const itemSelectItems = [
    { label: "Revenue", value: "Revenue" },
    { label: "Other Income", value: "Other Income" }
  ];

  return (
    <>
      <form className="p-d-flex p-jc-between">
        <Dropdown
          style={{ width: 250 }}
          value={item}
          options={itemSelectItems}
          onChange={e => {
            setItem(e.value);
          }}
          placeholder="Select an Item"
        />
        <Dropdown
          style={{ width: 250 }}
          value={year}
          options={yearSelectItems}
          onChange={e => {
            setYear(e.value);
          }}
          placeholder="Select Year"
        />
        <Button type="submit" label="Submit" style={{ width: 250 }} />
      </form>
      <DataTable
        value={allAccount}
        selection={selectedAccounts}
        onSelectionChange={e => {
          setSelectedAccounts(e.value);
        }}
        style={{ marginTop: 50 }}>
        <Column selectionMode="multiple" style={{ width: "3em" }} />
        <Column field="accountDescription" header="Account Description"></Column>
        <Column field="debitAmount" header="Debit Amount"></Column>
        <Column field="creditAmount" header="Credit Amount"></Column>
        <Column field="mappedCode" header="Mapped To"></Column>
      </DataTable>
    </>
  );
};

export default MappingMode;
