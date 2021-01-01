import React from "react";
import { Button } from "primereact/button";
import { Controller, useForm } from "react-hook-form";
import TrialBalanceMappingTable from "../common/TrialBalanceMappingTable";
// import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import InputController from "../controllers/InputController";
import { incomeTaxMapping } from "../../apis/IncomeTax";

const IncomeTaxMapping = ({ tbData, trialBalanceRefresh, toast }) => {
  const { errors, handleSubmit, control } = useForm();
  // const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState(false);
  const [selectedAccounts, setSelectedAccounts] = React.useState([]);

  const onSubmit = async data => {
    if (loading) return;
    const { lossBroughtFoward, unrelievedCapitalAllowanceBroughtFoward } = data;

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
      const response = await incomeTaxMapping({
        lossBroughtFoward: lossBroughtFoward === "" ? 0 : lossBroughtFoward,
        unrelievedCapitalAllowanceBroughtFoward:
          unrelievedCapitalAllowanceBroughtFoward === ""
            ? 0
            : unrelievedCapitalAllowanceBroughtFoward,
        trialBalanceId: selectedAccounts.map(item => item.id)
      });
      if (response.status === 200) {
        toast.show(
          utils.toastCallback({
            severity: "success",
            detail: "Income tax mapped successfully"
          })
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
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="lossBroughtFoward"
          label="Loss B/F"
          required={false}
          width={250}
        />
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="unrelievedCapitalAllowanceBroughtFoward"
          label="Unrelieved Capital Allowance B/F"
          required={false}
          width={250}
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
        tbData={tbData}
        trialBalanceRefresh={trialBalanceRefresh}
        toast={toast}
        selectedAccounts={selectedAccounts}
        setSelectedAccounts={setSelectedAccounts}
      />
    </>
  );
};

export default IncomeTaxMapping;
