import React from "react";
import { Button } from "primereact/button";
import { Checkbox } from "primereact/checkbox";
import utils from "../../utils";
import { Controller, useForm } from "react-hook-form";
import { useCompany } from "../../store/CompanyStore";
import { fixedAssetMapping } from "../../apis/FixedAsset";
import TrialBalanceMappingTable from "../common/TrialBalanceMappingTable";
import DropdownController from "../controllers/DropdownController";
import InputController from "../controllers/InputController";
import { useResources } from "../../store/ResourcesStore";

const FixedAssetMapping = ({
  assetClassSelectItems,
  tbData,
  onTrialBalance,
  trialBalanceRefresh,
  toast
}) => {
  const cost = "cost";
  const depreciation = "depreciation";
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [{ financialYears }] = useResources();
  const [closingBalance, setClosingBalance] = React.useState();
  const [loading, setLoading] = React.useState(false);
  const [init, setInit] = React.useState(true);
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
        (accumulator, current) =>
          accumulator + (selectedAssetType === cost ? current.debit : current.credit),
        0
      );
      setClosingBalance(value);
      setClosingBalanceAmt(utils.currencyFormatter(value));
    }
  }, [selectedAccounts, selectedAssetType]);

  React.useEffect(() => {
    if (tbData.length > 0 && init) trialBalanceRefresh();
    setInit(false);
  }, [init, tbData, trialBalanceRefresh]);

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
        utils.onMappingSuccess(
          toast,
          "Fixed asset mapped successfully",
          onTrialBalance,
          trialBalanceRefresh,
          setSelectedAccounts
        );
      }
    } catch (error) {
      utils.apiErrorHandling(error, toast);
    } finally {
      setLoading(false);
    }
  };

  return (
    <>
      <form className="p-d-flex p-flex-column p-jc-between" onSubmit={handleSubmit(onSubmit)}>
        <div className="p-d-flex p-ai-start p-jc-between" style={{ marginBottom: 20 }}>
          <DropdownController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="assetClass"
            label="Fixed Asset Class"
            required
            dropdownOptions={assetClassSelectItems}
            errorMessage="Fixed Asset Class is required"
          />
          <DropdownController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="assetType"
            label="Cost / Depreciation"
            required
            dropdownOptions={typeSelectItems}
            onChangeCallback={setSelectedAssetType}
            errorMessage="Fixed Asset Type is required"
          />
          <DropdownController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="year"
            label="Year"
            required
            dropdownOptions={financialYears}
            errorMessage="Year is required"
          />
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="closingBalance"
            label="Closing Balance"
            disabled
            placeholder="Closing Balance"
            defaultValue={closingBalanceAmt}
            value={closingBalanceAmt}
          />
        </div>
        <div className="p-d-flex p-ai-start p-jc-between">
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="openingBalance"
            label="Opening Balance"
            required
            errorMessage="Opening Balance is required"
          />
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="addition"
            label={selectedAssetType === "depreciation" ? "Charge per year" : "Addition"}
            required
            errorMessage="Addition is required"
          />
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="disposal"
            label="Disposal"
            required
            errorMessage="Disposal is required"
          />
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="transfer"
            label="Transfer"
            required
            errorMessage="Transfer is required"
          />
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
