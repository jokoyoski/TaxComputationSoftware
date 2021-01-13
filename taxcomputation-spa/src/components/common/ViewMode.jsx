import React from "react";
import { useCompany } from "../../store/CompanyStore";
import ViewModeHeaders from "./ViewModeHeaders";
import { Button } from "primereact/button";
import printStyles from "../../styles/printStyles";

const ViewMode = ({ title, year, children }) => {
  const [{ companyName }] = useCompany();

  const printElement = (el, title) => {
    let mywindow = window.open("", "PRINT", "height=650,width=900,top=100,left=150");

    mywindow.document.write(`<html><head><title>${title}</title>${printStyles}`);
    mywindow.document.write("</head><body >");
    mywindow.document.write(document.querySelector(el).innerHTML);
    mywindow.document.write("</body></html>");

    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/

    mywindow.print();
    mywindow.close();

    return true;
  };

  return (
    <div id="view-container" style={{ position: "relative" }}>
      <div style={{ textAlign: "left", marginBottom: 20 }}>
        <Button
          type="button"
          icon="pi pi-external-link"
          label="Export"
          onClick={() => printElement(".view-mode", "Tax Computation")}></Button>
      </div>
      <div className="view-mode">
        <ViewModeHeaders
          headers={[
            companyName.toUpperCase(),
            {
              "Fixed Asset": "ANALYSIS OF FIXED ASSET MOVEMENT",
              "Profit & Loss": "SUMMARY OF PROFIT & LOSS ACCOUNTS",
              "Income Tax": "INCOME TAX COMPUTATION",
              "Deferred Tax": "DEFERRED TAX COMPUTATION",
              "Minimum Tax": "MINIMUM TAX COMPUTATION",
              "I.T Levy": "I.T. LEVY COMPUTATION",
              "Investment Allowance": "COMPUTATION OF INVESTMENT ALLOWANCE",
              "Balancing Adjustment": "COMPUTATION OF BALANCING ALLOWANCE/CHARGE"
            }[title]
          ]}
        />
        {children}
      </div>
    </div>
  );
};

export default ViewMode;
