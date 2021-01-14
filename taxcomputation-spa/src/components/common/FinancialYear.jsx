import React from "react";
import { Dialog } from "primereact/dialog";
import { Button } from "primereact/button";
import { useForm, Controller } from "react-hook-form";
import DropdownController from "../controllers/DropdownController";
import { useResources } from "../../store/ResourcesStore";
import utils from "../../utils";
import { useCompany } from "../../store/CompanyStore";

const FinancialYear = ({ showFinancialYear, setShowFinancialYear, setShowSettings }) => {
  const { errors, control } = useForm();
  const [{ companyId }] = useCompany();
  const [selectedValue, setSelectedValue] = React.useState();
  const [
    { financialYears, selectedFinancialYear },
    { onFinancialYear, onSelectedFinancialYear }
  ] = useResources();

  React.useEffect(() => {
    utils.fetchCompanyFinancialYear({ companyId }, onFinancialYear, null);
  }, [companyId, onFinancialYear]);

  React.useEffect(() => {
    if (selectedFinancialYear === selectedValue) {
      setShowFinancialYear(false);
      if (setShowSettings) setShowSettings(false);
      window.location.reload();
    }
  }, [selectedFinancialYear, selectedValue, setShowFinancialYear, setShowSettings]);

  return (
    <div className="p-d-flex p-jc-center p-ai-center overlay">
      <Dialog
        style={{ width: 500 }}
        header="Financial Year"
        visible={showFinancialYear}
        blockScroll
        focusOnShow={false}
        closeOnEscape={selectedFinancialYear}
        closable={selectedFinancialYear}
        onHide={() => {
          setShowFinancialYear(false);
          if (setShowSettings) setShowSettings(false);
        }}
        footer={
          <Button
            type="button"
            label="Select"
            disabled={!selectedValue}
            onClick={() => {
              onSelectedFinancialYear(selectedValue);
              sessionStorage.setItem("year", selectedValue);
            }}
          />
        }>
        <div className="p-d-flex p-flex-column">
          <div>
            <DropdownController
              Controller={Controller}
              control={control}
              errors={errors}
              controllerName="financialYear"
              dropdownOptions={financialYears}
              onChangeCallback={setSelectedValue}
              width="100%"
              label="Select default financial year"
            />
          </div>
          <div
            className="p-d-flex p-ai-center"
            style={{ fontSize: 14, marginTop: 15, marginBottom: 200 }}>
            <i
              className="pi pi-info-circle"
              style={{ marginRight: 10, color: "#01a4e4", fontSize: 20 }}></i>
            <span>
              This will be used as the default financial year when viewing any module during this
              session
            </span>
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default FinancialYear;
