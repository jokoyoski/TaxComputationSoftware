import React from "react";
import { Button } from "primereact/button";
import { Controller, useForm } from "react-hook-form";
import DropdownController from "../controllers/DropdownController";
import TrialBalanceMappingTable from "../common/TrialBalanceMappingTable";
import constants from "../../constants";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import { profitAndLossMapping } from "../../apis/ProfitAndLoss";

const ProfitAndLossMapping = ({
  year,
  setYear,
  yearSelectItems,
  assetClassSelectItems,
  tbData,
  trialBalanceRefresh,
  toast
}) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState(false);
  const [selectedAccounts, setSelectedAccounts] = React.useState([]);

  const onSubmit = async data => {
    if (loading) return;
    const { profitAndLossId, yearId } = data;

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
      const response = await profitAndLossMapping({
        profitAndLossId,
        trialBalanceList: selectedAccounts,
        companyId,
        yearId,
        mappedCode: "profitandloss"
      });
      if (response.status === 200) {
        toast.show(
          utils.toastCallback({
            severity: "success",
            detail: "Profit and Loss mapped successfully"
          })
        );
      }
    } catch (error) {
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
      <form className="p-d-flex p-jc-between" onSubmit={handleSubmit(onSubmit)}>
        <DropdownController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="profitAndLossId"
          label="Profit and Loss Item"
          placeholder="Select Item"
          width={250}
          required
          dropdownOptions={assetClassSelectItems}
          errorMessage="Profit and Loss Item is required"
        />
        <DropdownController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="yearId"
          label="Year"
          width={250}
          required
          dropdownOptions={yearSelectItems}
          onChangeCallback={setYear}
          errorMessage="Year is required"
          defaultValue={year}
        />
        <div>
          <p style={{ color: "transparent", marginTop: 0, marginBottom: 5 }}>Submit</p>
          <Button
            type="submit"
            label={!loading ? "Submit" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: 250 }}
          />
        </div>
      </form>
      <TrialBalanceMappingTable
        title={constants.modules.profit_loss}
        tbData={tbData}
        trialBalanceRefresh={trialBalanceRefresh}
        toast={toast}
        selectedAccounts={selectedAccounts}
        setSelectedAccounts={setSelectedAccounts}
      />
    </>
  );
};

export default ProfitAndLossMapping;
