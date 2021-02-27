import React from "react";
import { Button } from "primereact/button";
import { Controller, useForm } from "react-hook-form";
import { minimumTaxMapping } from "../../apis/MinimumTax";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import DropdownController from "../controllers/DropdownController";
import InputController from "../controllers/InputController";
import { useResources } from "../../store/ResourcesStore";

const MinimumTaxMapping = ({ toast }) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [{ financialYears }] = useResources();
  const [loading, setLoading] = React.useState(false);

  const onSubmit = async data => {
    if (loading) return;

    const { financialYearId, grossProft, netAsset, shareCapital } = data;

    setLoading(true);
    try {
      const response = await minimumTaxMapping({
        financialYearId,
        grossProft,
        netAsset,
        shareCapital,
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
      utils.apiErrorHandling(error, toast);
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
          controllerName="financialYearId"
          label="Tax Year"
          required
          dropdownOptions={financialYears}
          errorMessage="Tax Year is required"
          labelWidth={120}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          type="number"
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="netAsset"
          label="Net Asset"
          required
          errorMessage="Net Asset is required"
          labelWidth={120}
          className="p-d-flex p-ai-center"
        />
      </div>
      <div style={{ marginBottom: 10 }}>
        <InputController
          type="number"
          Controller={Controller}
          control={control}
          errors={errors}
          controllerName="shareCapital"
          label="Share Capital"
          required
          errorMessage="Share Capital is required"
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

export default MinimumTaxMapping;
