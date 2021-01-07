import React from "react";
import { Dialog } from "primereact/dialog";
import { InputText } from "primereact/inputtext";
import { Button } from "primereact/button";
import { useForm, Controller } from "react-hook-form";
import { addCompany } from "../../apis/Companies";
import constants from "../../constants";
import utils from "../../utils";

const AddCompanyForm = ({ showAddCompany, setShowAddCompany, toast, refresh }) => {
  const { errors, handleSubmit, control } = useForm();
  const [loading, setLoading] = React.useState(false);

  const onSubmit = async data => {
    if (loading) return;

    setLoading(true);
    const {
      companyName,
      cacNumber,
      tinNumber,
      companyDescription,
      openingYear,
      monthOfOperation,
      unRelievedCf,
      lossCf,
      deferredTaxBroughtFoward
    } = data;
    try {
      const response = await addCompany({
        companyName,
        cacNumber,
        tinNumber,
        companyDescription,
        openingYear,
        monthOfOperation,
        unRelievedCf,
        lossCf,
        deferredTaxBroughtFoward
      });
      if (response.status === 201) {
        toast.show(
          utils.toastCallback({ severity: "success", detail: "Company added successfully" })
        );
        setTimeout(() => {
          setLoading(false);
          setShowAddCompany(false);
          refresh();
        }, 2000);
      }
    } catch (error) {
      setLoading(false);
      if (error.response) {
        const {
          data: { errors }
        } = error.response;
        // display main error as toast notification
        if (!errors?.error?.companyError && !errors?.error?.CompanyDescription) {
          errors.map(err =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: err }))
          );
          return;
        }
        // display all errors as toast notification
        errors?.error?.companyError &&
          errors.error.companyError.map(err =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: err }))
          );
        errors?.error?.CompanyDescription &&
          errors.error.CompanyDescription.map(err =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: err }))
          );
      } else {
        // network errors
        toast.show(
          utils.toastCallback({
            summary: "Network Error",
            detail: constants.networkErrorMessage
          })
        );
      }
    }
  };

  return (
    <Dialog
      header="Add Company"
      visible={showAddCompany}
      style={{ width: 400 }}
      focusOnShow={false}
      onHide={() => setShowAddCompany(false)}>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <label htmlFor="companyNameInput" style={{ marginBottom: 10 }}>
            Company Name
          </label>
          <Controller
            name="companyName"
            control={control}
            rules={{ required: true }}
            defaultValue=""
            render={props => (
              <InputText
                style={{ marginBottom: 5, width: "100%" }}
                id="companyNameInput"
                value={props.value}
                onChange={e => props.onChange(e.target.value)}
              />
            )}
          />
          {errors.companyName && (
            <span style={{ fontSize: 12, color: "red" }}>Company Name is required</span>
          )}
        </div>
        <div className="p-d-flex">
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginRight: 10 }}>
            <label htmlFor="cacNumberInput" style={{ marginBottom: 10 }}>
              Cac Number
            </label>
            <Controller
              name="cacNumber"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%" }}
                  id="cacNumberInput"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.cacNumber && (
              <span style={{ fontSize: 12, color: "red" }}>Cac Number is required</span>
            )}
          </div>
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginLeft: 10 }}>
            <label htmlFor="tinNumberInput" style={{ marginBottom: 10 }}>
              Tin Number
            </label>
            <Controller
              name="tinNumber"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%" }}
                  id="tinNumberInput"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.tinNumber && (
              <span style={{ fontSize: 12, color: "red" }}>Tin Number is required</span>
            )}
          </div>
        </div>
        <div className="p-d-flex">
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginRight: 10 }}>
            <label htmlFor="unRelievedCfInput" style={{ marginBottom: 10 }}>
              Unrelieved C/f
            </label>
            <Controller
              name="unRelievedCf"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%" }}
                  id="unRelievedCfInput"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.unRelievedCf && (
              <span style={{ fontSize: 12, color: "red" }}>Unrelieved C/f is required</span>
            )}
          </div>
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginLeft: 10 }}>
            <label htmlFor="lossCfInput" style={{ marginBottom: 10 }}>
              Loss C/f
            </label>
            <Controller
              name="lossCf"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%" }}
                  id="lossCfInput"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.lossCf && (
              <span style={{ fontSize: 12, color: "red" }}>Loss C/f is required</span>
            )}
          </div>
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <label htmlFor="deferredTaxBroughtFowardInput" style={{ marginBottom: 10 }}>
            Deferred Tax Brought Foward
          </label>
          <Controller
            name="deferredTaxBroughtFoward"
            control={control}
            rules={{ required: true }}
            defaultValue=""
            render={props => (
              <InputText
                style={{ marginBottom: 5, width: "100%" }}
                id="deferredTaxBroughtFowardInput"
                value={props.value}
                onChange={e => props.onChange(e.target.value)}
              />
            )}
          />
          {errors.deferredTaxBroughtFoward && (
            <span style={{ fontSize: 12, color: "red" }}>
              Deferred Tax Brought Foward is required
            </span>
          )}
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <label htmlFor="openingYearInput" style={{ marginBottom: 10 }}>
            Last Opening Financial Year
          </label>
          <Controller
            name="openingYear"
            control={control}
            rules={{ required: true }}
            defaultValue=""
            render={props => (
              <InputText
                style={{ marginBottom: 5, width: "100%" }}
                id="openingYearInput"
                value={props.value}
                onChange={e => props.onChange(e.target.value)}
              />
            )}
          />
          {errors.openingYear && (
            <span style={{ fontSize: 12, color: "red" }}>
              Last Opening Financial Year is required
            </span>
          )}
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <label htmlFor="monthOfOperationInput" style={{ marginBottom: 10 }}>
            Month of Operation
          </label>
          <Controller
            name="monthOfOperation"
            control={control}
            rules={{ required: true }}
            defaultValue=""
            render={props => (
              <InputText
                style={{ marginBottom: 5, width: "100%" }}
                id="monthOfOperationInput"
                value={props.value}
                onChange={e => props.onChange(e.target.value)}
              />
            )}
          />
          {errors.monthOfOperation && (
            <span style={{ fontSize: 12, color: "red" }}>Month of Operation is required</span>
          )}
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <label htmlFor="companyDescriptionInput" style={{ marginBottom: 10 }}>
            Address
          </label>
          <Controller
            name="companyDescription"
            control={control}
            rules={{ required: true }}
            defaultValue=""
            render={props => (
              <InputText
                style={{ marginBottom: 5, width: "100%" }}
                id="companyDescriptionInput"
                value={props.value}
                onChange={e => props.onChange(e.target.value)}
              />
            )}
          />
          {errors.companyDescription && (
            <span style={{ fontSize: 12, color: "red" }}>Address is required</span>
          )}
        </div>
        <Button
          label={!loading ? "Add Company" : null}
          icon={loading ? "pi pi-spin pi-spinner" : null}
          type="submit"
          style={{ width: "100%", marginTop: 10 }}
        />
      </form>
    </Dialog>
  );
};

export default AddCompanyForm;
