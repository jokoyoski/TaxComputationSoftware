import React from "react";
import { Button } from "primereact/button";
import { Controller, useForm } from "react-hook-form";
import TrialBalanceMappingTable from "../common/TrialBalanceMappingTable";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import DropdownController from "../controllers/DropdownController";
import InputController from "../controllers/InputController";
import { deferredTaxMapping } from "../../apis/DeferredTax";
import constants from "../../constants";

const DeferredTaxMapping = ({
  tbData,
  yearSelectItems,
  onTrialBalance,
  trialBalanceRefresh,
  toast
}) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState(false);
  const [init, setInit] = React.useState(true);
  const [selectedAccounts, setSelectedAccounts] = React.useState([]);
  const fairValueGainItems = [
    {
      label: "Fair value gain on invt property",
      value: 1
    }
  ];

  React.useEffect(() => {
    if (tbData.length > 0 && init) trialBalanceRefresh();
    setInit(false);
  }, [init, tbData, trialBalanceRefresh]);

  const onSubmit = async data => {
    if (loading) return;
    const { fairValueGainId, yearId, deferredTaxBroughtFoward } = data;

    if (deferredTaxBroughtFoward !== "" && isNaN(deferredTaxBroughtFoward)) {
      toast.show(
        utils.toastCallback({
          severity: "error",
          detail: "Deferred Tax B/F is not a numeric value"
        })
      );
      return;
    }

    if (selectedAccounts.length === 0) {
      toast.show(
        utils.toastCallback({
          severity: "error",
          detail: "Select at least one account from the trial balance table"
        })
      );
      return;
    }

    setLoading(true);

    try {
      const response = await deferredTaxMapping({
        fairValueGainId,
        deferredTaxBroughtFoward: deferredTaxBroughtFoward === "" ? 0 : deferredTaxBroughtFoward,
        trialBalanceList: selectedAccounts,
        companyId,
        yearId
      });
      if (response.status === 200) {
        utils.onMappingSuccess(
          toast,
          "Deferred tax mapped successfully",
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
      <form className="p-d-flex p-jc-between" onSubmit={handleSubmit(onSubmit)}>
        <DropdownController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="fairValueGainId"
          label="Fair Value Gain"
          required
          dropdownOptions={fairValueGainItems}
          errorMessage="Fair Value Gain is required"
          width={200}
        />
        <DropdownController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="yearId"
          label="Year"
          required
          dropdownOptions={yearSelectItems}
          errorMessage="Year is required"
          width={200}
        />
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="deferredTaxBroughtFoward"
          label="Deferred Tax B/F"
          required={false}
          width={200}
        />
        <div>
          <p style={{ color: "transparent", marginTop: 0, marginBottom: 5 }}>Submit</p>
          <Button
            type="submit"
            label={!loading ? "Submit" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: 200 }}
          />
        </div>
      </form>
      <TrialBalanceMappingTable
        title={constants.modules.incomeTax}
        tbData={tbData}
        trialBalanceRefresh={trialBalanceRefresh}
        toast={toast}
        selectedAccounts={selectedAccounts}
        setSelectedAccounts={setSelectedAccounts}
      />
    </>
  );
};

export default DeferredTaxMapping;
