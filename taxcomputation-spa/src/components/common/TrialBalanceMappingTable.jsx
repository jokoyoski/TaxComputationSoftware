import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";
import { fixedAssetUnmapping } from "../../apis/FixedAsset";

const TrialBalanceMappingTable = ({
  tbData,
  selectedAccounts,
  setSelectedAccounts,
  trialBalanceRefresh,
  toast,
  toastCallback
}) => {
  return (
    <DataTable
      value={tbData}
      paginator
      rows={10}
      rowsPerPageOptions={[10, 20, 50, 100]}
      className="p-datatable-gridlines"
      selection={selectedAccounts}
      onSelectionChange={e => {
        if (e.value.length > 0) {
          !tbData.find(d => d.id === e.value[e.value.length - 1].id).mappedTo &&
            setSelectedAccounts(e.value);
        } else {
          setSelectedAccounts(e.value);
        }
      }}
      style={{ marginTop: 50 }}>
      <Column selectionMode="multiple" style={{ width: "3em" }} />
      <Column field="accountId" header="Account ID"></Column>
      <Column field="item" header="Account Description"></Column>
      <Column field="debitAmt" header="Debit Amt"></Column>
      <Column field="creditAmt" header="Credit Amt"></Column>
      <Column field="mappedTo" header="Mapped To"></Column>
      <Column
        field="unmap"
        header="Unmap"
        body={rowData =>
          rowData.mappedTo && (
            <Button
              className="p-button-danger p-button-text"
              label="Unmap"
              onClick={async () => {
                const response = await fixedAssetUnmapping({ id: rowData.id });
                if (response.status === 200) {
                  trialBalanceRefresh();
                  toast.show(
                    toastCallback({
                      severity: "success",
                      detail: response.data
                    })
                  );
                }
              }}
            />
          )
        }></Column>
    </DataTable>
  );
};

export default TrialBalanceMappingTable;
