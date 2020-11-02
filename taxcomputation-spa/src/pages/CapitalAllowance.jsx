import React from "react";
import Layout from "../components/layout";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import CapitalAllowanceView from "../components/capital_allowance/CapitalAllowanceView";
import Main from "../components/layout/Main";
import utils from "../utils";
import { usePathParam } from "react-resource-router";

const CapitalAllowance = () => {
  const title = constants.modules.capitalAllowance;
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
        <ViewMode title={title} year={year}>
          <CapitalAllowanceView />
        </ViewMode>
      </Main>
    </Layout>
  );
};

export default CapitalAllowance;
