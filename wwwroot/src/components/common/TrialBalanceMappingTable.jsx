import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";

const TrialBalanceMappingTable = ({ tbData, selectedAccounts, setSelectedAccounts }) => {
  return (
    <DataTable
      value={tbData}
      className="p-datatable-gridlines"
      selection={selectedAccounts}
      onSelectionChange={e => setSelectedAccounts(e.value)}
      style={{ marginTop: 50 }}>
      <Column selectionMode="multiple" style={{ width: "3em" }} />
      <Column field="accountId" header="Account ID"></Column>
      <Column field="item" header="Account Description"></Column>
      <Column field="debitAmt" header="Debit Amt"></Column>
      <Column field="creditAmt" header="Credit Amt"></Column>
      <Column field="mappedCode" header="Mapped To"></Column>
    </DataTable>
  );
};

export default TrialBalanceMappingTable;
