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
      closingYear
    } = data;
    try {
      const response = await addCompany({
        companyName,
        cacNumber,
        tinNumber,
        companyDescription,
        openingYear,
        closingYear
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
            <label htmlFor="openingYearInput" style={{ marginBottom: 10 }}>
              Opening Year
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
              <span style={{ fontSize: 12, color: "red" }}>Opening Year is required</span>
            )}
          </div>
          <div className="p-d-flex p-flex-column" style={{ marginBottom: 15, marginLeft: 10 }}>
            <label htmlFor="closingYearInput" style={{ marginBottom: 10 }}>
              Closing Year
            </label>
            <Controller
              name="closingYear"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%" }}
                  id="closingYearInput"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.closingYear && (
              <span style={{ fontSize: 12, color: "red" }}>Closing Year is required</span>
            )}
          </div>
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
