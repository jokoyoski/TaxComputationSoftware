import React from "react";
import { Dialog } from "primereact/dialog";
import { Button } from "primereact/button";
import { Dropdown } from "primereact/dropdown";

const CompanyPicker = ({
  setShowAddCompany,
  showCompanyPicker,
  setShowCompanyPicker,
  company,
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
            disabled={!company.companyId}
            onClick={() => company.companyId && setShowCompanyPicker(false)}
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
          value={company}
          options={companySelectItems}
          optionLabel="name"
          autoFocus
          filter
          filterBy="name"
          onChange={e => {
            onSelectCompany(e.value);
            sessionStorage.setItem("cid", e.value.companyId);
          }}
          placeholder="Select a Company"
        />
        {companySelectItems && companySelectItems.length === 0 && (
          <div className="p-d-flex p-ai-center" style={{ fontSize: 14, marginTop: 15 }}>
            <i
              className="pi pi-exclamation-triangle"
              style={{ marginRight: 10, color: "#FBC02D", fontSize: 20 }}></i>
            <span>There are currently no companies, click add company button.</span>
          </div>
        )}
      </div>
    </Dialog>
  );
};

export default CompanyPicker;
