import React from "react";
import { Dropdown } from "primereact/dropdown";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Controller, useForm } from "react-hook-form";
import { balancingAdjustmentAdding } from "../../apis/BalancingAdjustment";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import constants from "../../constants";

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
      if (error.response) {
        toast.show(
          utils.toastCallback({
            severity: "error",
            summary: "Error",
            detail:
              "An error occurred while calculating balancing adjustment, kindly contact your admin."
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
    <form className="p-d-flex p-flex-column p-jc-between" onSubmit={handleSubmit(onSubmit)}>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 120 }}>Year</p>
          <Controller
            name="year"
            control={control}
            rules={{ required: true }}
            defaultValue=""
            render={props => (
              <Dropdown
                style={{ marginBottom: 5, width: 200 }}
                value={props.value}
                options={yearSelectItems}
                onChange={e => props.onChange(e.target.value)}
              />
            )}
          />
        </div>
        {errors.year && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 120 }}>Year is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 120 }}>Asset</p>
          <Controller
            name="assetId"
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
        </div>
        {errors.assetId && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 120 }}>Asset is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 120 }}>Cost</p>
          <Controller
            name="cost"
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
        </div>
        {errors.cost && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 120 }}>Cost is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 120 }}>Sales Proceed</p>
          <Controller
            name="salesProceed"
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
        </div>
        {errors.salesProceed && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 120 }}>
            Sales Proceed is required
          </div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 120 }}>Year Bought</p>
          <Controller
            name="yearBought"
            control={control}
            rules={{ required: true }}
            defaultValue=""
            render={props => (
              <Dropdown
                style={{ marginBottom: 5, width: 200 }}
                value={props.value}
                options={yearSelectItems}
                onChange={e => props.onChange(e.target.value)}
              />
            )}
          />
        </div>
        {errors.yearBought && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 120 }}>Year Bought is required</div>
        )}
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
