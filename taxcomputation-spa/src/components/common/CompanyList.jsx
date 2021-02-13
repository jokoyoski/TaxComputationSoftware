import React from "react";
import { Dialog } from "primereact/dialog";
import { Button } from "primereact/button";
import Loader from "./Loader";
import { useResources } from "../../store/ResourcesStore";
import { getCompanies } from "../../apis/Companies";
import CompanyItem from "./CompanyItem";

const CompanyList = ({ showCompanyList, setShowCompanyList, setShowCompanyDetails }) => {
  const [loading, setLoading] = React.useState(false);
  const [error, setError] = React.useState(null);
  const [{ companyList }, { onCompanyList, onSelectedCompany }] = useResources();

  React.useEffect(() => {
    const fetchCompanies = async () => {
      if (!companyList) {
        try {
          setLoading(true);
          setError(null);
          const data = await getCompanies();
          if (data) onCompanyList(data);
        } catch (error) {
          setError("Failed to get all companies");
        } finally {
          setLoading(false);
        }
      }
    };
    fetchCompanies();
  }, [companyList, onCompanyList]);

  return (
    <Dialog
      header="Company List"
      footer={<div style={{ height: 10 }}></div>}
      visible={showCompanyList}
      style={{ width: 500 }}
      blockScroll
      focusOnShow={false}
      closeOnEscape
      closable
      onHide={() => {
        setShowCompanyList(false);
        onSelectedCompany(null);
      }}>
      <div className="p-d-flex p-flex-column" style={{ height: 300 }}>
        {loading && (
          <div
            className="p-d-flex p-jc-center p-ai-center"
            style={{ height: "100%", width: "100%" }}>
            <Loader />
          </div>
        )}
        {error && (
          <div
            className="p-d-flex p-flex-column p-jc-center p-ai-center"
            style={{ height: "100%", width: "100%" }}>
            <p style={{ marginTop: 10, marginBottom: 10, marginRight: 10 }}>{error}</p>
            <Button
              className="p-button-outlined"
              label="Retry"
              onClick={() => onCompanyList(null)}
            />
          </div>
        )}
        {companyList &&
          companyList.map(item => (
            <CompanyItem
              key={item.id}
              companyData={item}
              onCompanyList={onCompanyList}
              setShowCompanyList={setShowCompanyList}
              setShowCompanyDetails={setShowCompanyDetails}
              onSelectedCompany={onSelectedCompany}
            />
          ))}
      </div>
    </Dialog>
  );
};

export default CompanyList;
