import React from "react";
import ViewModeHeaders from "./ViewModeHeaders";

const ViewMode = ({ title, children }) => {
  return (
    <>
      <ViewModeHeaders
        headers={[
          "ACCESS PENSION FUND CUSTODIAN LIMITED",
          "2020 INCOME TAX COMPUTATIONS",
          "AUDITED ACCOUNTS FOR THE YEAR ENDED 31 DECEMBER, 2019",
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
