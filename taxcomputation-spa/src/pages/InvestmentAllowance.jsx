import React from "react";
import Layout from "../components/layout";
import MappingMode from "../components/common/MappingMode";
import InvestmentAllowanceView from "../components/investment_allowance/InvestmentAllowanceView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import Main from "../components/layout/Main";
import utils from "../utils";

const InvestmentAllowance = () => {
  const title = constants.modules.investmentAllowance;
  const [mode, setMode] = React.useState("mapping");
  const [year, setYear] = React.useState(utils.currentYear());
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

  return (
    <Layout title={title}>
      <Main
        title={title}
        mode={mode}
        setMode={setMode}
        year={year}
        setYear={setYear}
        yearSelectItems={yearSelectItems}>
        {
          {
            mapping: <MappingMode />,
            view: (
              <ViewMode title={title}>
                <InvestmentAllowanceView />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default InvestmentAllowance;
