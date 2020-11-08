import React from "react";
import { Dropdown } from "primereact/dropdown";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Controller, useForm } from "react-hook-form";
// import { useCompany } from "../../store/CompanyStore";

const BalancingAdjustmentAdding = ({
  yearSelectItems,
  assetClassSelectItems
  // toast
}) => {
  const { errors, handleSubmit, control } = useForm();
  // const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState(false);

  const onSubmit = async data => {
    if (loading) return;

    setLoading(true);
  };

  return (
    <form className="p-d-flex p-flex-column p-jc-between" onSubmit={handleSubmit(onSubmit)}>
      <div className="p-d-flex p-ai-center" style={{ marginBottom: 10 }}>
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
        {errors.year && <span style={{ fontSize: 12, color: "red" }}>Year is required</span>}
      </div>
      <div className="p-d-flex p-ai-center" style={{ marginBottom: 10 }}>
        <p style={{ marginBottom: 5, marginTop: 0, width: 120 }}>Asset</p>
        <Controller
          name="asset"
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
        {errors.asset && <span style={{ fontSize: 12, color: "red" }}>Asset is required</span>}
      </div>
      <div className="p-d-flex p-ai-center" style={{ marginBottom: 10 }}>
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
        {errors.cost && <span style={{ fontSize: 12, color: "red" }}>Cost is required</span>}
      </div>
      <div className="p-d-flex p-ai-center" style={{ marginBottom: 10 }}>
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
        {errors.salesProceed && (
          <span style={{ fontSize: 12, color: "red" }}>Sales Proceed is required</span>
        )}
      </div>
      <div className="p-d-flex p-ai-center" style={{ marginBottom: 10 }}>
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
        {errors.yearBought && (
          <span style={{ fontSize: 12, color: "red" }}>Year Bought is required</span>
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
