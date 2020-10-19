import React from "react";
import { Dropdown } from "primereact/dropdown";
import { Button } from "primereact/button";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { InputText } from "primereact/inputtext";
import utils from "../../utils";
import { Controller, useForm } from "react-hook-form";
import { useCompany } from "../../store/CompanyStore";
import constants from "../../constants";
import { fixedAssetMapping } from "../../apis/FixedAsset";

const FixedAssetMapping = ({
  year,
  setYear,
  yearSelectItems,
  assetClassSelectItems,
  tbData,
  toast,
  toastCallback
}) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [closingBalance, setClosingBalance] = React.useState();
  const [loading, setLoading] = React.useState(false);
  const [closingBalanceAmt, setClosingBalanceAmt] = React.useState(utils.currencyFormatter(0));
  const [selectedAccounts, setSelectedAccounts] = React.useState([]);
  const typeSelectItems = [
    { label: "Cost", value: "cost" },
    { label: "Depreciation", value: "depreciation" }
  ];

  React.useEffect(() => {
    if (selectedAccounts) {
      const value = selectedAccounts.reduce(
        (accumulator, current) => accumulator + current.debit,
        0
      );
      setClosingBalance(value);
      setClosingBalanceAmt(utils.currencyFormatter(value));
    }
  }, [selectedAccounts]);

  const onSubmit = async data => {
    if (loading) return;

    const { assetClass, assetType, year, openingBalance, addition, disposal } = data;

    if (selectedAccounts.length === 0) {
      toast.show(
        toastCallback({
          severity: "error",
          detail: "Select at least one account from the trial balance table"
        })
      );
      return;
    }

    if (isNaN(openingBalance)) {
      toast.show(
        toastCallback({
          severity: "error",
          detail: "Opening balance is not a number"
        })
      );
      return;
    } else if (isNaN(addition)) {
      toast.show(
        toastCallback({
          severity: "error",
          detail: "Addition is not a number"
        })
      );
      return;
    } else if (isNaN(disposal)) {
      toast.show(
        toastCallback({
          severity: "error",
          detail: "Disposal is not a number"
        })
      );
      return;
    }

    setLoading(true);

    try {
      const response = await fixedAssetMapping({
        companyId,
        yearId: year,
        mappedCode: "fixedasset",
        assetId: assetClass,
        triBalanceId: selectedAccounts.map(account => account.id),
        isCost: assetType === "cost" ? true : false,
        openingCost: assetType === "cost" ? Number(openingBalance) : 0,
        costAddition: assetType === "cost" ? Number(addition) : 0,
        costDisposal: assetType === "cost" ? Number(disposal) : 0,
        costClosing: assetType === "cost" ? Number(closingBalance) : 0,
        openingDepreciation: assetType !== "cost" ? Number(openingBalance) : 0,
        depreciationAddition: assetType !== "cost" ? Number(addition) : 0,
        depreciationDisposal: assetType !== "cost" ? Number(disposal) : 0,
        depreciationClosing: assetType !== "cost" ? Number(closingBalance) : 0
      });
      if (response.status === 200) {
        toast.show(
          toastCallback({ severity: "success", detail: "Fixed asset mapped successfully" })
        );
      }
    } catch (error) {
      // network errors
      toast.show(
        toastCallback({
          severity: "error",
          summary: "Network Error",
          detail: constants.networkErrorMessage
        })
      );
    } finally {
      setLoading(false);
    }
  };

  return (
    <>
      <form className="p-d-flex p-flex-column p-jc-between" onSubmit={handleSubmit(onSubmit)}>
        <div className="p-d-flex p-ai-start p-jc-between" style={{ marginBottom: 20 }}>
          <div className="p-d-flex p-flex-column">
            <p style={{ marginBottom: 5, marginTop: 0 }}>Fixed Asset Class</p>
            <Controller
              name="assetClass"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <Dropdown
                  style={{ marginBottom: 5, width: 200 }}
                  value={props.value}
                  options={assetClassSelectItems}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.assetClass && (
              <span style={{ fontSize: 12, color: "red" }}>Fixed Asset Class is required</span>
            )}
          </div>
          <div className="p-d-flex p-flex-column">
            <p style={{ marginBottom: 5, marginTop: 0 }}>Fixed Asset Type</p>
            <Controller
              name="assetType"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <Dropdown
                  style={{ marginBottom: 5, width: 200 }}
                  value={props.value}
                  options={typeSelectItems}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.assetType && (
              <span style={{ fontSize: 12, color: "red" }}>Fixed Asset Type is required</span>
            )}
          </div>
          <div className="p-d-flex p-flex-column">
            <p style={{ marginBottom: 5, marginTop: 0 }}>Year</p>
            <Controller
              name="year"
              control={control}
              rules={{ required: true }}
              defaultValue={year}
              render={_ => (
                <Dropdown
                  style={{ marginBottom: 5, width: 200 }}
                  value={year}
                  options={yearSelectItems}
                  onChange={e => setYear(e.target.value)}
                  placeholder="Year"
                />
              )}
            />
            {errors.year && <span style={{ fontSize: 12, color: "red" }}>Year is required</span>}
          </div>
          <div className="p-d-flex p-flex-column">
            <p style={{ marginBottom: 5, marginTop: 0 }}>Closing Balance</p>
            <Controller
              name="closingBalance"
              control={control}
              defaultValue={closingBalanceAmt}
              render={_ => (
                <InputText
                  disabled
                  style={{ width: 200 }}
                  placeholder="Closing Balance"
                  value={closingBalanceAmt}
                />
              )}
            />
          </div>
        </div>
        <div className="p-d-flex p-ai-start p-jc-between">
          <div className="p-d-flex p-flex-column">
            <p style={{ marginBottom: 5, marginTop: 0 }}>Opening Balance</p>
            <Controller
              name="openingBalance"
              control={control}
              rules={{ required: true }}
              defaultValue="0"
              render={props => (
                <InputText
                  style={{ width: 200 }}
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.openingBalance && (
              <span style={{ fontSize: 12, color: "red" }}>Opening Balance is required</span>
            )}
          </div>
          <div className="p-d-flex p-flex-column">
            <p style={{ marginBottom: 5, marginTop: 0 }}>Addition</p>
            <Controller
              name="addition"
              control={control}
              rules={{ required: true }}
              defaultValue="0"
              render={props => (
                <InputText
                  style={{ width: 200 }}
                  value={props.value}
                  onChange={e => props.onChange(e.target?.value)}
                />
              )}
            />
            {errors.addition && (
              <span style={{ fontSize: 12, color: "red" }}>Addition is required</span>
            )}
          </div>
          <div className="p-d-flex p-flex-column">
            <p style={{ marginBottom: 5, marginTop: 0 }}>Disposal</p>
            <Controller
              name="disposal"
              control={control}
              rules={{ required: true }}
              defaultValue="0"
              render={props => (
                <InputText
                  style={{ width: 200 }}
                  value={props.value}
                  onChange={e => props.onChange(e.target?.value)}
                />
              )}
            />
            {errors.disposal && (
              <span style={{ fontSize: 12, color: "red" }}>Disposal is required</span>
            )}
          </div>
          <div className="p-d-flex p-flex-column">
            <p style={{ marginBottom: 5, marginTop: 0, color: "transparent" }}>Submit</p>
            <Button
              type="submit"
              label={!loading ? "Submit" : null}
              icon={loading ? "pi pi-spin pi-spinner" : null}
              style={{ width: 200 }}
            />
          </div>
        </div>
      </form>
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
    </>
  );
};

export default FixedAssetMapping;
