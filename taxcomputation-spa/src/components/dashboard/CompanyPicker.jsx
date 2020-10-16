import React from "react";
import { Dialog } from "primereact/dialog";
import { Button } from "primereact/button";
import { Dropdown } from "primereact/dropdown";

const CompanyPicker = ({
  setShowAddCompany,
  showCompanyPicker,
  setShowCompanyPicker,
  company,
  setCompany
}) => {
  const companySelectItems = [
    { name: "Landmark", value: "Landmark" },
    { name: "Interswitch", value: "Interswitch" }
  ];

  const handleSubmit = e => {
    e.preventDefault();
    setShowCompanyPicker(false);
  };

  return (
    <Dialog
      header="Company"
      visible={showCompanyPicker}
      style={{ width: 400 }}
      focusOnShow={false}
      closeOnEscape={false}
      closable={false}
      onHide={() => setShowCompanyPicker(false)}>
      <form onSubmit={handleSubmit}>
        <div className="p-d-flex p-flex-column">
          <label htmlFor="companyNameInput" style={{ margin: "0px 0px 10px 0px" }}>
            Select a company or add a new company
          </label>
          <Dropdown
            value={company}
            options={companySelectItems}
            optionLabel="name"
            filter
            filterBy="name"
            onChange={e => {
              setCompany(e.value);
            }}
            placeholder="Company"
          />
        </div>
        <Button label="Select Company" type="submit" style={{ width: "100%", marginTop: 20 }} />
        <Button
          className="p-button-outlined"
          label="Add Company"
          type="button"
          style={{ width: "100%", marginTop: 20 }}
          onClick={() => {
            setShowAddCompany(true);
            setShowCompanyPicker(false);
          }}
        />
      </form>
    </Dialog>
  );
};

export default CompanyPicker;
