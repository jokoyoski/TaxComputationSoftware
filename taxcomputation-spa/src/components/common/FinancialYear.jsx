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
  const [
    { financialYears, selectedFinancialYear },
    { onFinancialYear, onSelectedFinancialYear }
  ] = useResources();

  React.useEffect(() => {
    utils.fetchCompanyFinancialYear({ companyId }, onFinancialYear, null);
  }, [companyId, onFinancialYear]);

  return (
    <div className="p-d-flex p-jc-center p-ai-center overlay">
      <Dialog
        style={{ width: 500 }}
        header="Financial Year"
        visible={showFinancialYear}
        blockScroll
        focusOnShow={false}
        closeOnEscape
        closable
        onHide={() => {
          setShowFinancialYear(false);
          if (setShowSettings) setShowSettings(false);
        }}
        footer={
          <Button
            type="button"
            label="Select"
            disabled={!selectedFinancialYear}
            onClick={() => {
              sessionStorage.setItem("year", selectedFinancialYear);
              setShowFinancialYear(false);
              if (setShowSettings) setShowSettings(false);
              window.location.reload();
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
              onChangeCallback={onSelectedFinancialYear}
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
