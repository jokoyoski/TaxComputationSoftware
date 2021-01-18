import { Button } from "primereact/button";
import React from "react";

const CompanyItem = ({
  companyData,
  setShowCompanyList,
  setShowCompanyDetails,
  onSelectedCompany
}) => {
  return (
    <div className="p-d-flex p-jc-between p-ai-center company-item">
      <p style={{ marginTop: 10, marginBottom: 10 }}>{companyData.companyName}</p>
      <div>
        <Button
          label="View"
          className="p-button-text"
          onClick={() => {
            onSelectedCompany(companyData.id);
            setShowCompanyList(false);
            setShowCompanyDetails(true);
          }}
        />
      </div>
    </div>
  );
};

export default CompanyItem;
