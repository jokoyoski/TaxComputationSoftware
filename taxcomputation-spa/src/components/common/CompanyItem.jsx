import React from "react";
import { deleteCompany } from "../../apis/Companies";

const CompanyItem = ({
  companyData,
  onCompanyList,
  setShowCompanyList,
  setShowCompanyDetails,
  setShowAddEditCompany,
  onSelectedCompany
}) => {
  const [isDeleting, setIsDeleting] = React.useState(false);

  const companyInfoHandler = () => {
    onSelectedCompany(companyData.id);
    setShowCompanyDetails(true);
    setShowCompanyList(false);
  };

  const editCompanyHandler = () => {
    onSelectedCompany(companyData.id);
    setShowAddEditCompany(true);
    setShowCompanyList(false);
  };

  const deleteCompanyHandler = async () => {
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
      <p className="company-item-name">{companyData.companyName}</p>
      <div>
        <i className="pi pi-info-circle info" onClick={companyInfoHandler} />
        <i className="pi pi-pencil edit" style={{ marginLeft: 20 }} onClick={editCompanyHandler} />
        <i
          className={isDeleting ? "pi pi-spin pi-spinner" : "pi pi-trash delete"}
          style={{ marginLeft: 20, marginRight: 10 }}
          onClick={deleteCompanyHandler}
        />
      </div>
    </div>
  );
};

export default CompanyItem;
