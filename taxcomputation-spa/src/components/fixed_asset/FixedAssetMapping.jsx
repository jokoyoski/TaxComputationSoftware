import React from "react";
import { Dropdown } from "primereact/dropdown";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Checkbox } from "primereact/checkbox";
import utils from "../../utils";
import { Controller, useForm } from "react-hook-form";
import { useCompany } from "../../store/CompanyStore";
import constants from "../../constants";
import { fixedAssetMapping } from "../../apis/FixedAsset";
import TrialBalanceMappingTable from "../common/TrialBalanceMappingTable";

const FixedAssetMapping = ({
  year,
  setYear,
  yearSelectItems,
  assetClassSelectItems,
  tbData,
  trialBalanceRefresh,
  toast
}) => {
  const cost = "cost";
  const depreciation = "depreciation";
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [closingBalance, setClosingBalance] = React.useState();
  const [loading, setLoading] = React.useState(false);
  const [closingBalanceAmt, setClosingBalanceAmt] = React.useState(utils.currencyFormatter(0));
  const [selectedAccounts, setSelectedAccounts] = React.useState([]);
  const [selectedAssetType, setSelectedAssetType] = React.useState();
  const [transferChecked, setTransferChecked] = React.useState();
  const typeSelectItems = [
    { label: "Cost", value: cost },
    { label: "Depreciation", value: depreciation }
  ];

  React.useEffect(() => {
    trialBalanceRefresh();
  }, [trialBalanceRefresh]);

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

    const { assetClass, assetType, year, openingBalance, addition, disposal, transfer } = data;

    if (selectedAccounts.length === 0) {
      toast.show(
        utils.toastCallback({
          severity: "error",
          detail: "Select at least one account from the trial balance table"
        })
      );
      return;
    }

    if (isNaN(openingBalance)) {
      toast.show(
        utils.toastCallback({
          severity: "error",
          detail: "Opening balance is not a number"
        })
      );
      return;
    } else if (isNaN(addition)) {
      toast.show(
        utils.toastCallback({
          severity: "error",
          detail: `${assetType === cost ? "Addition" : "Charge per year"} value is not a number`
        })
      );
      return;
    } else if (isNaN(disposal)) {
      toast.show(
        utils.toastCallback({
          severity: "error",
          detail: "Disposal value is not a number"
        })
      );
      return;
    } else if (isNaN(transfer)) {
      toast.show(
        utils.toastCallback({
          severity: "error",
          detail: "Transfer value is not a number"
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
        isCost: assetType === cost ? true : false,
        openingCost: assetType === cost ? Number(openingBalance) : 0,
        transferCost: assetType === cost ? Number(transfer) : 0,
        transferDepreciation: assetType !== cost ? Number(transfer) : 0,
        isTransferCostRemoved: assetType === cost ? transferChecked : false,
        isTransferDepreciationRemoved: assetType !== cost ? transferChecked : false,
        costAddition: assetType === cost ? Number(addition) : 0,
        costDisposal: assetType === cost ? Number(disposal) : 0,
        costClosing: assetType === cost ? Number(closingBalance) : 0,
        openingDepreciation: assetType !== cost ? Number(openingBalance) : 0,
        depreciationAddition: assetType !== cost ? Number(addition) : 0,
        depreciationDisposal: assetType !== cost ? Number(disposal) : 0,
        depreciationClosing: assetType !== cost ? Number(closingBalance) : 0
      });
      if (response.status === 200) {
        toast.show(
          utils.toastCallback({ severity: "success", detail: "Fixed asset mapped successfully" })
        );
      }
    } catch (error) {
      // network errors
      toast.show(
        utils.toastCallback({
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
            <p style={{ marginBottom: 5, marginTop: 0 }}>Cost / Depreciation</p>
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
                  onChange={e => {
                    props.onChange(e.target.value);
                    setSelectedAssetType(e.target.value);
                  }}
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
              defaultValue=""
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
            <p style={{ marginBottom: 5, marginTop: 0 }}>
              {selectedAssetType === "depreciation" ? "Charge per year" : "Addition"}
            </p>
            <Controller
              name="addition"
              control={control}
              rules={{ required: true }}
              defaultValue=""
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
              defaultValue=""
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
            <p style={{ marginBottom: 5, marginTop: 0 }}>Transfer</p>
            <Controller
              name="transfer"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ width: 200 }}
                  value={props.value}
                  onChange={e => props.onChange(e.target?.value)}
                />
              )}
            />
            {errors.transfer && (
              <span style={{ fontSize: 12, color: "red" }}>Transfer is required</span>
            )}
          </div>
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginTop: 20 }}>
          <div className="p-field-checkbox">
            <Checkbox
              inputId="transferOut"
              checked={transferChecked}
              onChange={e => setTransferChecked(e.checked)}
            />
            <label htmlFor="transferOut">Transfer Out</label>
          </div>
          <Button
            type="submit"
            label={!loading ? "Submit" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: 200 }}
          />
        </div>
      </form>
      <TrialBalanceMappingTable
        tbData={tbData}
        trialBalanceRefresh={trialBalanceRefresh}
        toast={toast}
        selectedAccounts={selectedAccounts}
        setSelectedAccounts={setSelectedAccounts}
      />
    </>
  );
};

export default FixedAssetMapping;
