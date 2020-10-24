import React from "react";
import Layout from "../components/layout";
import InvestmentAllowanceView from "../components/investment_allowance/InvestmentAllowanceView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import Main from "../components/layout/Main";
import utils from "../utils";
import { usePathParam } from "react-resource-router";

const InvestmentAllowance = () => {
  const title = constants.modules.investmentAllowance;
  const [mode, setMode] = usePathParam("mode");
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
        <ViewMode title={title}>
          <InvestmentAllowanceView />
        </ViewMode>
      </Main>
    </Layout>
  );
};

export default InvestmentAllowance;
