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
          <div style={{ marginBottom: 200 }}>
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
        </div>
      </Dialog>
    </div>
  );
};

export default FinancialYear;
