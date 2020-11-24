import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";
import { fixedAssetUnmapping } from "../../apis/FixedAsset";
import constants from "../../constants";
import utils from "../../utils";
import { Checkbox } from "primereact/checkbox";

const TrialBalanceMappingTable = ({
  title,
  tbData,
  selectedAccounts,
  setSelectedAccounts,
  trialBalanceRefresh,
  toast
}) => {
  const [debitRowChecks, setDebitRowChecks] = React.useState([]);
  const [creditRowChecks, setCreditRowChecks] = React.useState([]);

  return (
    <DataTable
      className="p-datatable-gridlines"
      value={tbData}
      paginator={tbData.length !== 0}
      rows={10}
      rowsPerPageOptions={[10, 20, 50, 100]}
      selection={selectedAccounts}
      onSelectionChange={e => {
        if (e.value.length > 0) {
          !tbData.find(d => d.id === e.value[e.value.length - 1].id).mappedTo
            ? setSelectedAccounts(e.value)
            : toast.show(
                utils.toastCallback({
                  severity: "error",
                  detail: "This item has been mapped"
                })
              );
        } else {
          setSelectedAccounts(e.value);
        }
      }}
      style={{ marginTop: 50 }}
      footer={
        tbData.length === 0 && (
          <>
            <div className="p-d-flex p-ai-center p-jc-center">
              <p>No Trial Balance data, upload a Trial Balance file</p>
            </div>
          </>
        )
      }>
      {title === constants.modules.profit_loss && (
        <Column
          field="isDebitChecked"
          header="Debit"
          style={{ width: "5em", textAlign: "center" }}
          body={rowData => {
            return (
              <Checkbox
                onChange={e => {
                  setDebitRowChecks(state => {
                    if (e.checked) return state.concat([rowData.id]);
                    else return state.filter(id => id !== rowData.id);
                  });
                  if (rowData.mappedTo) {
                    toast.show(
                      utils.toastCallback({
                        severity: "error",
                        detail: "This item has been mapped"
                      })
                    );
                  } else {
                    if (e.checked) {
                      let selectedAccountIndex;
                      const selectedAccount = selectedAccounts.find((selectedAccount, index) => {
                        selectedAccountIndex = index;
                        return selectedAccount.trialBalanceId === rowData.id;
                      });
                      if (selectedAccount) {
                        setSelectedAccounts(state => {
                          state[selectedAccountIndex] = {
                            ...state[selectedAccountIndex],
                            trialBalanceId: rowData.id,
                            isDebit: true,
                            isCredit: true,
                            isBoth: true
                          };
                          return state;
                        });
                      } else {
                        setSelectedAccounts([
                          ...selectedAccounts,
                          {
                            trialBalanceId: rowData.id,
                            isDebit: true,
                            isCredit: false,
                            isBoth: false
                          }
                        ]);
                      }
                    } else {
                      let selectedAccountIndex;
                      const selectedAccount = selectedAccounts.find((selectedAccount, index) => {
                        selectedAccountIndex = index;
                        return selectedAccount.trialBalanceId === rowData.id;
                      });
                      if (selectedAccount?.isCredit) {
                        setSelectedAccounts(state => {
                          state[selectedAccountIndex] = {
                            ...state[selectedAccountIndex],
                            trialBalanceId: rowData.id,
                            isDebit: false,
                            isCredit: true,
                            isBoth: false
                          };
                          return state;
                        });
                      } else {
                        setSelectedAccounts(
                          selectedAccounts.filter(
                            selectedAccount => selectedAccount.trialBalanceId !== rowData.id
                          )
                        );
                      }
                    }
                  }
                }}
                checked={debitRowChecks.includes(rowData.id)}></Checkbox>
            );
          }}
        />
      )}
      {title === constants.modules.profit_loss && (
        <Column
          field="isCreditChecked"
          header="Credit"
          style={{ width: "5em", textAlign: "center" }}
          body={rowData => {
            return (
              <Checkbox
                onChange={e => {
                  setCreditRowChecks(state => {
                    if (e.checked) return state.concat([rowData.id]);
                    else return state.filter(id => id !== rowData.id);
                  });
                  if (rowData.mappedTo) {
                    toast.show(
                      utils.toastCallback({
                        severity: "error",
                        detail: "This item has been mapped"
                      })
                    );
                  } else {
                    if (e.checked) {
                      let selectedAccountIndex;
                      const selectedAccount = selectedAccounts.find((selectedAccount, index) => {
                        selectedAccountIndex = index;
                        return selectedAccount.trialBalanceId === rowData.id;
                      });
                      if (selectedAccount) {
                        setSelectedAccounts(state => {
                          state[selectedAccountIndex] = {
                            ...state[selectedAccountIndex],
                            trialBalanceId: rowData.id,
                            isDebit: true,
                            isCredit: true,
                            isBoth: true
                          };
                          return state;
                        });
                      } else {
                        setSelectedAccounts([
                          ...selectedAccounts,
                          {
                            trialBalanceId: rowData.id,
                            isDebit: false,
                            isCredit: true,
                            isBoth: false
                          }
                        ]);
                      }
                    } else {
                      let selectedAccountIndex;
                      const selectedAccount = selectedAccounts.find((selectedAccount, index) => {
                        selectedAccountIndex = index;
                        return selectedAccount.trialBalanceId === rowData.id;
                      });
                      if (selectedAccount?.isDebit) {
                        setSelectedAccounts(state => {
                          state[selectedAccountIndex] = {
                            ...state[selectedAccountIndex],
                            trialBalanceId: rowData.id,
                            isDebit: true,
                            isCredit: false,
                            isBoth: false
                          };
                          return state;
                        });
                      } else {
                        setSelectedAccounts(
                          selectedAccounts.filter(
                            selectedAccount => selectedAccount.trialBalanceId !== rowData.id
                          )
                        );
                      }
                    }
                  }
                }}
                checked={creditRowChecks.includes(rowData.id)}></Checkbox>
            );
          }}
        />
      )}
      {title !== constants.modules.profit_loss && (
        <Column selectionMode="multiple" style={{ width: "3.5em", textAlign: "center" }} />
      )}
      <Column field="accountId" header="Account ID"></Column>
      <Column field="item" header="Account Description"></Column>
      <Column field="debitAmt" header="Debit Amt"></Column>
      <Column field="creditAmt" header="Credit Amt"></Column>
      {tbData && tbData.some(d => d.mappedTo) && (
        <Column field="mappedTo" header="Mapped To"></Column>
      )}
      {tbData && tbData.some(d => d.mappedTo) && (
        <Column
          field="unmap"
          header="Unmap"
          body={rowData =>
            rowData.mappedTo && (
              <Button
                className="p-button-danger p-button-text"
                label="Unmap"
                onClick={async () => {
                  try {
                    const response = await fixedAssetUnmapping({ id: rowData.id });
                    if (response.status === 200) {
                      trialBalanceRefresh();
                      toast.show(
                        utils.toastCallback({
                          severity: "success",
                          detail: response.data
                        })
                      );
                    }
                  } catch (error) {
                    if (error.message === "Network Error") {
                      return toast.show(
                        utils.toastCallback({
                          severity: "success",
                          detail: constants.networkErrorMessage
                        })
                      );
                    }
                    trialBalanceRefresh();
                  }
                }}
              />
            )
          }></Column>
      )}
    </DataTable>
  );
};

export default TrialBalanceMappingTable;
