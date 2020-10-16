import React from "react";
import { Dropdown } from "primereact/dropdown";
import { Button } from "primereact/button";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { InputText } from "primereact/inputtext";

const FixedAssetMapping = ({ year, setYear, yearSelectItems }) => {
  const [assetClass, setAssetClass] = React.useState();
  const [closingBalance, setClosingBalance] = React.useState();
  const [openingBalance, setOpeningBalance] = React.useState();
  const [addition, setAddition] = React.useState();
  const [disposal, setDisposal] = React.useState();
  const [type, setType] = React.useState();
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
  const assetClassSelectItems = [
    { label: "Furniture & Fittings", value: "Furniture & Fittings" },
    { label: "Motor Vehicles", value: "Motor Vehicle" },
    { label: "Plant & Equipment", value: "Plant & Equipment" }
  ];
  const typeSelectItems = [
    { label: "Cost", value: "Cost" },
    { label: "Depreciation", value: "Depreciation" }
  ];

  return (
    <>
      <form className="p-d-flex p-flex-column p-jc-between">
        <div className="p-d-flex p-jc-between" style={{ marginBottom: 20 }}>
          <Dropdown
            style={{ width: 200 }}
            value={assetClass}
            options={assetClassSelectItems}
            onChange={e => {
              setAssetClass(e.value);
            }}
            placeholder="Fixed Asset Class"
          />
          <Dropdown
            style={{ width: 200 }}
            value={type}
            options={typeSelectItems}
            onChange={e => {
              setType(e.value);
            }}
            placeholder="Fixed Asset Type"
          />
          <Dropdown
            style={{ width: 200 }}
            value={year}
            options={yearSelectItems}
            onChange={e => {
              setYear(e.value);
            }}
            placeholder="Select Year"
          />
          <InputText
            disabled
            style={{ width: 200 }}
            placeholder="Closing Balance"
            value={closingBalance}
            onChange={e => setClosingBalance(e.target.value)}
          />
        </div>
        <div className="p-d-flex p-jc-between">
          <InputText
            style={{ width: 200 }}
            placeholder="Opening Balance"
            value={openingBalance}
            onChange={e => setOpeningBalance(e.target.value)}
          />
          <InputText
            style={{ width: 200 }}
            placeholder="Addition"
            value={addition}
            onChange={e => setAddition(e.target.value)}
          />
          <InputText
            style={{ width: 200 }}
            placeholder="Disposal"
            value={disposal}
            onChange={e => setDisposal(e.target.value)}
          />
          <Button type="submit" label="Submit" style={{ width: 200 }} />
        </div>
      </form>
      <DataTable
        value={allAccount}
        className="p-datatable-gridlines"
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

export default FixedAssetMapping;
