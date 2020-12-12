import React from "react";
import { Button } from "primereact/button";
import { Controller, useForm } from "react-hook-form";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import constants from "../../constants";
import DropdownController from "../controllers/DropdownController";
import { investmentAllowanceMapping } from "../../apis/InvestmentAllowance";

const InvestmentAllowanceMapping = ({ yearSelectItems, assetClassSelectItems, toast }) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState(false);

  const onSubmit = async data => {
    if (loading) return;

    const { yearId, assetId } = data;

    setLoading(true);
    try {
      const response = await investmentAllowanceMapping({
        companyId,
        assetId,
        yearId
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
      if (error.response) {
        toast.show(
          utils.toastCallback({
            severity: "error",
            summary: "Error",
            detail:
              "An error occurred while calculating investment allowance, kindly contact your admin."
          })
        );
        return;
      }
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
    <div style={{ height: 300 }}>
      <form className="p-d-flex p-flex-column p-jc-between" onSubmit={handleSubmit(onSubmit)}>
        <div style={{ marginBottom: 10 }}>
          <DropdownController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="yearId"
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
        <div className="p-d-flex p-flex-column" style={{ marginTop: 10 }}>
          <Button
            type="submit"
            label={!loading ? "Submit" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: 320 }}
          />
        </div>
      </form>
    </div>
  );
};

export default InvestmentAllowanceMapping;
