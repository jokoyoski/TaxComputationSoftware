import React from "react";
import { Dialog } from "primereact/dialog";
import { Button } from "primereact/button";
import { Dropdown } from "primereact/dropdown";

const CompanyPicker = ({
  setShowAddCompany,
  showCompanyPicker,
  setShowCompanyPicker,
  companyId,
  onSelectCompany,
  companySelectItems
}) => {
  return (
    <Dialog
      header="Company"
      footer={
        <div>
          <Button
            label="Add Company"
            onClick={() => {
              setShowAddCompany(true);
              setShowCompanyPicker(false);
            }}
            className="p-button-outlined"
          />
          <Button
            label="Proceed"
            disabled={!companyId}
            onClick={() => companyId && setShowCompanyPicker(false)}
          />
        </div>
      }
      visible={showCompanyPicker}
      style={{ width: 500 }}
      blockScroll
      focusOnShow={false}
      closeOnEscape={false}
      closable={false}
      onHide={() => setShowCompanyPicker(false)}>
      <div className="p-d-flex p-flex-column" style={{ height: 300 }}>
        <label htmlFor="companyNameInput" style={{ margin: "0px 0px 10px 0px" }}></label>
        <Dropdown
          value={companyId}
          options={companySelectItems}
          optionLabel="name"
          autoFocus
          filter
          filterBy="name"
          onChange={e => {
            onSelectCompany(e.value);
          }}
          placeholder="Select a Company"
        />
      </div>
    </Dialog>
  );
};

export default CompanyPicker;
