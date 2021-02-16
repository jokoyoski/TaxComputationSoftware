import React from "react";
import { Dialog } from "primereact/dialog";
import { Calendar } from "primereact/calendar";
import { Button } from "primereact/button";
import { useForm, Controller } from "react-hook-form";
import { addCompany } from "../../apis/Companies";
import constants from "../../constants";
import utils from "../../utils";
import InputController from "../controllers/InputController";
import DropdownController from "../controllers/DropdownController";

const AddCompanyForm = ({ showAddCompany, setShowAddCompany, toast, refresh }) => {
  const { errors, handleSubmit, control } = useForm();
  const [loading, setLoading] = React.useState(false);
  const minimumTaxTypeSelectItems = [
    { label: "Old", value: 0 },
    { label: "New", value: 1 }
  ];

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
      deferredTaxBroughtFoward,
      minimumTaxTypeId
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
        deferredTaxBroughtFoward,
        minimumTaxTypeId
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
        // display all errors as toast notification
        errors?.companyError &&
          errors.error.companyError.map(error =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: error }))
          );
        errors?.CompanyDescription &&
          errors.CompanyDescription.map(error =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: error }))
          );
        errors?.deferredTaxBroughtFoward &&
          errors.deferredTaxBroughtFoward.map(error =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: error }))
          );
        errors?.lossCf &&
          errors.lossCf.map(error =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: error }))
          );
        errors?.unRelievedCf &&
          errors.unRelievedCf.map(error =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: error }))
          );
        errors?.monthOfOperation &&
          errors.monthOfOperation.map(error =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: error }))
          );
        if (errors.length) {
          errors.forEach(error =>
            toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: error }))
          );
        }
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
      style={{ width: 450 }}
      focusOnShow={false}
      onHide={() => setShowAddCompany(false)}>
      <form onSubmit={handleSubmit(onSubmit)} className="p-d-flex p-flex-column p-jc-center">
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="companyName"
            label="Company Name"
            required
            errorMessage="Company Name is required"
            width="100%"
          />
        </div>
        <div className="p-d-flex">
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginRight: 10 }}>
            <InputController
              Controller={Controller}
              control={control}
              errors={errors}
              controllerName="cacNumber"
              label="Cac Number"
              required
              errorMessage="Cac Number is required"
              width="100%"
            />
          </div>
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginLeft: 10 }}>
            <InputController
              Controller={Controller}
              control={control}
              errors={errors}
              controllerName="tinNumber"
              label="Tin Number"
              required
              errorMessage="Tin Number is required"
              width="100%"
            />
          </div>
        </div>
        <div className="p-d-flex">
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginRight: 10 }}>
            <InputController
              Controller={Controller}
              control={control}
              errors={errors}
              controllerName="unRelievedCf"
              label="Unrelieved CA b/f"
              required
              errorMessage="Unrelieved CA b/f is required"
              width="100%"
            />
          </div>
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginLeft: 10 }}>
            <InputController
              Controller={Controller}
              control={control}
              errors={errors}
              controllerName="lossCf"
              label="Loss b/f"
              required
              errorMessage="Loss b/f is required"
              width="100%"
            />
          </div>
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <DropdownController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="minimumTaxTypeId"
            label="Minimum Tax Type"
            required
            dropdownOptions={minimumTaxTypeSelectItems}
            errorMessage="Minimum Tax Type is required"
            width="100%"
          />
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="deferredTaxBroughtFoward"
            label="Deferred Tax Brought Forward"
            required
            errorMessage="Deferred Tax Brought Forward is required"
            width="100%"
          />
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="monthOfOperation"
            label="Month(s) of Operation"
            required
            errorMessage="Month(s) of Operation is required"
            width="100%"
          />
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <label htmlFor="openingYearInput" style={{ marginBottom: 10 }}>
            Closing Financial Year
          </label>
          <Controller
            name="openingYear"
            control={control}
            rules={{ required: true }}
            defaultValue=""
            render={props => (
              <Calendar
                style={{ marginBottom: 5, width: "100%" }}
                id="openingYearInput"
                dateFormat="yy/mm/dd"
                value={props.value}
                onChange={e => props.onChange(e.target.value)}
              />
            )}
          />
          {errors.openingYear && (
            <span style={{ fontSize: 12, color: "red" }}>Closing Financial Year is required</span>
          )}
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 15 }}>
          <InputController
            Controller={Controller}
            control={control}
            errors={errors}
            controllerName="companyDescription"
            label="Address"
            required
            errorMessage="Address is required"
            width="100%"
          />
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
