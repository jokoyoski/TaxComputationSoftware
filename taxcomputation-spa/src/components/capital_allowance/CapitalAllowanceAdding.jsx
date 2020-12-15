import React from "react";
import { Button } from "primereact/button";
import { Controller, useForm } from "react-hook-form";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import { capitalAllowanceAdding } from "../../apis/CapitalAllowance";
import DropdownController from "../controllers/DropdownController";
import InputController from "../controllers/InputController";

const CapitalAllowanceAdding = ({ yearSelectItems, assetClassSelectItems, toast }) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState(false);

  const onSubmit = async data => {
    if (loading) return;

    const {
      taxYear,
      assetId,
      openingResidue,
      addition,
      disposal,
      initial,
      annual,
      total,
      closingResidue,
      yearsToGo
    } = data;

    setLoading(true);
    try {
      const response = await capitalAllowanceAdding({
        companyId,
        taxYear,
        assetId,
        openingResidue,
        addition,
        disposal,
        initial,
        annual,
        total,
        closingResidue,
        yearsToGo
      });
      if (response.status === 200) {
        toast.show(
          utils.toastCallback({
            severity: "success",
            detail: response.data
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
          controllerName="taxYear"
          label="Tax Year"
          required
          dropdownOptions={yearSelectItems}
          errorMessage="Tax Year is required"
          labelWidth={150}
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
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="openingResidue"
          label="Opening Residue"
          required
          errorMessage="Opening Residue is required"
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="addition"
          label="Addition"
          required
          errorMessage="Addition is required"
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="disposal"
          label="Disposal"
          required
          errorMessage="Disposal is required"
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="initial"
          label="Initial"
          required
          errorMessage="Initial is required"
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="annual"
          label="Annual"
          required
          errorMessage="Annual is required"
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="total"
          label="Total"
          required
          errorMessage="Total is required"
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="closingResidue"
          label="Closing Residue"
          required
          errorMessage="Closing Residue is required"
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="yearsToGo"
          label="Years To Go"
          required
          errorMessage="Years To Go is required"
          labelWidth={150}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div className="p-d-flex p-flex-column" style={{ marginTop: 10 }}>
        <Button
          type="submit"
          label={!loading ? "Submit" : null}
          icon={loading ? "pi pi-spin pi-spinner" : null}
          style={{ width: 350 }}
        />
      </div>
    </form>
  );
};

export default CapitalAllowanceAdding;
