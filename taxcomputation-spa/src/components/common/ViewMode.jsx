import React from "react";
import { useCompany } from "../../store/CompanyStore";
import ViewModeHeaders from "./ViewModeHeaders";

const ViewMode = ({ title, year, children }) => {
  const [{ companyName }] = useCompany();
  return (
    <>
      <ViewModeHeaders
        headers={[
          companyName.toUpperCase(),
          `${year} INCOME TAX COMPUTATIONS`,
          `AUDITED ACCOUNTS FOR THE YEAR ENDED 31 DECEMBER, ${year - 1}`,
          {
            "Fixed Asset": "ANALYSIS OF FIXED ASSET MOVEMENT",
            "Profit & Loss": "SUMMARY OF PROFIT & LOSS ACCOUNTS",
            "Income Tax": "INCOME TAX COMPUTATION",
            "Deferred Tax": "DEFERRED TAX COMPUTATION",
            "Minimum Tax": "MINIMUM TAX COMPUTATION",
            "I.T Levy": "I.T. LEVY COMPUTATION (BASED ON THE 2007 CITA AMENDMENT)",
            "Investment Allowance": "COMPUTATION OF INVESTMENT ALLOWANCE",
            "Balancing Allowance": "COMPUTATION OF BALANCING ALLOWANCE/CHARGE"
          }[title]
        ]}
      />
      {children}
    </>
  );
};

export default ViewMode;
