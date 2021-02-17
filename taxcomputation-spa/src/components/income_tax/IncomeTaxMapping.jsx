import React from "react";
import { Button } from "primereact/button";
import { Controller, useForm } from "react-hook-form";
import TrialBalanceMappingTable from "../common/TrialBalanceMappingTable";
import utils from "../../utils";
import DropdownController from "../controllers/DropdownController";
import { incomeTaxMapping } from "../../apis/IncomeTax";
import constants from "../../constants";
import { useCompany } from "../../store/CompanyStore";
import { useResources } from "../../store/ResourcesStore";

const IncomeTaxMapping = ({ tbData, onTrialBalance, trialBalanceRefresh, toast }) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [{ financialYears }] = useResources();
  const [loading, setLoading] = React.useState(false);
  const [init, setInit] = React.useState(true);
  const [selectedAccounts, setSelectedAccounts] = React.useState([]);
  const typeItems = [
    {
      label: "Allowable Income",
      value: 1
    },
    {
      label: "Allowable Income",
      value: 1

    }
  ];

  React.useEffect(() => {
    if (tbData.length > 0 && init) trialBalanceRefresh();
    setInit(false);
  }, [init, tbData, trialBalanceRefresh]);

  const onSubmit = async data => {
    if (loading) return;
    const { typeId, yearId } = data;

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
        typeId,
        yearId,
        incomeList: selectedAccounts,
        companyId
      });
      if (response.status === 200) {
        utils.onMappingSuccess(
          toast,
          "Income tax mapped successfully",
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
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="p-d-flex p-jc-between">
          <DropdownController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="typeId"
            label="Type"
            required
            dropdownOptions={typeItems}
            errorMessage="Type is required"
            width={250}
          />
          <DropdownController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="yearId"
            label="Tax Year"
            required
            dropdownOptions={financialYears}
            errorMessage="Tax Year is required"
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

export default IncomeTaxMapping;
