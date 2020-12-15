import React from "react";
import { Button } from "primereact/button";
import { Controller, useForm } from "react-hook-form";
import { balancingAdjustmentAdding } from "../../apis/BalancingAdjustment";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import DropdownController from "../controllers/DropdownController";
import InputController from "../controllers/InputController";

const BalancingAdjustmentAdding = ({ yearSelectItems, assetClassSelectItems, toast }) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState(false);

  const onSubmit = async data => {
    if (loading) return;

    const { year, assetId, cost, salesProceed, yearBought } = data;

    setLoading(true);
    try {
      const response = await balancingAdjustmentAdding({
        year,
        assetId,
        cost,
        salesProceed,
        yearBought,
        companyId
      });
      if (response.status === 200) {
        toast.show(
          utils.toastCallback({
            severity: "success",
            detail: response.data.responseDescription
          })
        );
      }
    } catch (error) {
      utils.apiErrorHandling(error?.response?.data?.errors[0], toast);
    } finally {
      setLoading(false);
    }
  };

  return (
    <form className="p-d-flex p-flex-column p-jc-between" onSubmit={handleSubmit(onSubmit)}>
      <div style={{ marginBottom: 10 }}>
        <DropdownController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="year"
          label="Year"
          required
          dropdownOptions={yearSelectItems}
          errorMessage="Year is required"
          labelWidth={120}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <DropdownController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="assetId"
          label="Asset"
          required
          dropdownOptions={assetClassSelectItems}
          errorMessage="Asset is required"
          labelWidth={120}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="cost"
          label="Cost"
          required
          errorMessage="Cost is required"
          labelWidth={120}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="salesProceed"
          label="Sales Proceed"
          required
          errorMessage="Sales Proceed is required"
          labelWidth={120}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <DropdownController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="yearBought"
          label="Year Bought"
          required
          dropdownOptions={yearSelectItems}
          errorMessage="Year Bought is required"
          labelWidth={120}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div className="p-d-flex p-flex-column" style={{ marginTop: 10 }}>
        <Button
          type="submit"
          label={!loading ? "Submit" : null}
          icon={loading ? "pi pi-spin pi-spinner" : null}
          style={{ width: 320 }}
        />
      </div>
    </form>
  );
};

export default BalancingAdjustmentAdding;
