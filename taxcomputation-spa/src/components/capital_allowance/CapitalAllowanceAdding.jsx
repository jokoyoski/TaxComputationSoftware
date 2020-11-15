import React from "react";
import { Dropdown } from "primereact/dropdown";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Controller, useForm } from "react-hook-form";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import constants from "../../constants";
import { capitalAllowanceAdding } from "../../apis/CapitalAllowance";

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
      if (error.response) {
        toast.show(
          utils.toastCallback({
            severity: "error",
            summary: "Error",
            detail:
              "An error occurred while calculating capital allowance, kindly contact your admin."
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
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Tax Year</p>
          <Controller
            name="taxYear"
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
        {errors.taxYear && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>Tax Year is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Asset</p>
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
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>Asset is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Opening Residue</p>
          <Controller
            name="openingResidue"
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
        {errors.openingResidue && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>
            Opening Residue is required
          </div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Addition</p>
          <Controller
            name="addition"
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
        {errors.addition && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>Addition is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Disposal</p>
          <Controller
            name="disposal"
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
        {errors.disposal && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>Disposal is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Initial</p>
          <Controller
            name="initial"
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
        {errors.initial && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>Initial is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Annual</p>
          <Controller
            name="annual"
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
        {errors.annual && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>Annual is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Total</p>
          <Controller
            name="total"
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
        {errors.total && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>Total is required</div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Closing Residue</p>
          <Controller
            name="closingResidue"
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
        {errors.closingResidue && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>
            Closing Residue is required
          </div>
        )}
      </div>
      <div style={{ marginBottom: 10 }}>
        <div className="p-d-flex p-ai-center">
          <p style={{ marginBottom: 5, marginTop: 0, width: 150 }}>Years To Go</p>
          <Controller
            name="yearsToGo"
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
        {errors.yearsToGo && (
          <div style={{ fontSize: 12, color: "red", marginLeft: 150 }}>Years To Go is required</div>
        )}
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
