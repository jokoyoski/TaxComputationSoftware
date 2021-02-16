import React from "react";
import { useCompany } from "../../store/CompanyStore";
import ViewModeHeaders from "./ViewModeHeaders";
import { Button } from "primereact/button";
import printStyles from "../../styles/printStyles";
import { getCompanyViewHeaderData } from "../../apis/Companies";
import utils from "../../utils";

const ViewMode = ({ title, year: yearId, children }) => {
  const [{ companyId }] = useCompany();
  const [companyViewHeaderData, setCompanyViewHeaderData] = React.useState(null);

  const companyViewHeaderDataCallback = React.useCallback(async (companyId, yearId) => {
    try {
      // reset company view header data
      setCompanyViewHeaderData(null);
      // fetch company view header data
      const data = await getCompanyViewHeaderData(companyId, yearId);
      if (data) {
        setCompanyViewHeaderData(state => {
          const newState = {
            ...state,
            companyName: data["CompanyName"],
            year: data["Name"],
            closingDate: new Date(data["ClosingDate"]).toLocaleDateString()
          };

          return newState;
        });
      }
    } catch (error) {
      utils.apiErrorHandling(error);
    }
  }, []);

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

  React.useEffect(() => {
    if (!companyId) return;
    companyViewHeaderDataCallback(companyId, yearId);
  }, [companyId, companyViewHeaderDataCallback, yearId]);

  return (
    <div id="view-container" style={{ position: "relative", minHeight: 200 }}>
      <div style={{ textAlign: "left", marginBottom: 20 }}>
        <Button
          type="button"
          icon="pi pi-external-link"
          label="Export"
          onClick={() => printElement(".view-mode", "Tax Computation")}></Button>
      </div>
      <div className="view-mode">
        {companyViewHeaderData && (
          <ViewModeHeaders
            headers={[
              companyViewHeaderData.companyName.toUpperCase(),
              `${companyViewHeaderData.year} INCOME TAX COMPUTATIONS`,
              `AUDITED ACCOUNTS FOR THE YEAR ENDED ${companyViewHeaderData.closingDate}`,
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
        )}
        {children}
      </div>
    </div>
  );
};

export default ViewMode;
