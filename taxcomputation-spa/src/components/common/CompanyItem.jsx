import React from "react";
import { deleteCompany } from "../../apis/Companies";

const CompanyItem = ({
  companyData,
  onCompanyList,
  setShowCompanyList,
  setShowCompanyDetails,
  onSelectedCompany
}) => {
  const [isDeleting, setIsDeleting] = React.useState(false);

  const deleteAssetHandler = async () => {
    try {
      setIsDeleting(true);
      const response = await deleteCompany(companyData.id);
      if (response.status === 200) onCompanyList(null);
    } catch (error) {
      console.log("Failed to delete company");
    } finally {
      setIsDeleting(false);
    }
  };

  return (
    <div className="p-d-flex p-jc-between p-ai-center company-item">
      <p style={{ marginTop: 10, marginBottom: 10 }}>{companyData.companyName}</p>
      <div>
        <i
          className="pi pi-info-circle info"
          onClick={() => {
            onSelectedCompany(companyData.id);
            setShowCompanyList(false);
            setShowCompanyDetails(true);
          }}
        />
        <i
          className={isDeleting ? "pi pi-spin pi-spinner" : "pi pi-trash delete"}
          style={{ marginLeft: 20, marginRight: 10 }}
          onClick={deleteAssetHandler}
        />
      </div>
    </div>
  );
};

export default CompanyItem;
