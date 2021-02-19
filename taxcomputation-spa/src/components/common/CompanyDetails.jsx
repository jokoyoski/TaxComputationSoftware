import React from "react";
import { Dialog } from "primereact/dialog";
import { Button } from "primereact/button";
import Loader from "./Loader";
import useFetchCompanyDetails from "../hooks/useFetchCompanyDetails";

const CompanyDetails = ({
  companyId,
  showCompanyDetails,
  setShowCompanyDetails,
  setShowCompanyList
}) => {
  const { companyDetails, loading, error, fetchCompany } = useFetchCompanyDetails(companyId);

  return (
    <Dialog
      header="Company Details"
      footer={<div style={{ height: 10 }}></div>}
      visible={showCompanyDetails}
      style={{ width: 500 }}
      blockScroll
      focusOnShow={false}
      closeOnEscape
      closable
      onHide={() => {
        setShowCompanyDetails(false);
        setShowCompanyList(true);
      }}>
      <div className="p-d-flex p-flex-column" style={{ height: 350 }}>
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
            <Button className="p-button-outlined" label="Retry" onClick={() => fetchCompany()} />
          </div>
        )}
        {companyDetails && (
          <>
            <p className="company-details">
              <strong>Company Name:</strong> {companyDetails.companyName}
            </p>
            <p className="company-details">
              <strong>Company Description:</strong> {companyDetails.companyDescription}
            </p>
            <p className="company-details">
              <strong>CAC Number:</strong> {companyDetails.cacNumber}
            </p>
            <p className="company-details">
              <strong>TIN Number:</strong> {companyDetails.tinNumber}
            </p>
            <p className="company-details">
              <strong>Date Created:</strong>{" "}
              {new Date(companyDetails.dateCreated).toISOString().slice(0, 10)}
            </p>
            <p className="company-details">
              <strong>Opening Year:</strong>{" "}
              {new Date(companyDetails.openingYear).toISOString().slice(0, 10)}
            </p>
            <p className="company-details">
              <strong>Closing Year:</strong>{" "}
              {new Date(companyDetails.closingYear).toISOString().slice(0, 10)}
            </p>
            <p className="company-details">
              <strong>Minimum Tax Type:</strong>{" "}
              {companyDetails.minimumTaxTypeId === 1 ? "New" : "Old"}
            </p>
            <p className="company-details">
              <strong>Active:</strong> {companyDetails.isActive ? "Yes" : "No"}
            </p>
            <p className="company-details">
              <strong>Unrelieved Cf:</strong> {companyDetails.unRelievedCf}
            </p>
            <p className="company-details">
              <strong>Loss Cf:</strong> {companyDetails.lossCf}
            </p>
            <p className="company-details">
              <strong>Deferred Tax Brought Foward:</strong>{" "}
              {companyDetails.deferredTaxBroughtFoward}
            </p>
            <p className="company-details">
              <strong>Month of Operation:</strong> {companyDetails.monthOfOperation}
            </p>
          </>
        )}
      </div>
    </Dialog>
  );
};

export default CompanyDetails;
