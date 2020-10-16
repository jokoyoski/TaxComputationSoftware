import React from "react";
import Layout from "../components/layout";
import ProfitLossView from "../components/profit_loss/ProfitLossView";
import MappingMode from "../components/common/MappingMode";
import ViewMode from "../components/common/ViewMode";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam } from "react-resource-router";
import constants from "../constants";

const ProfitLoss = () => {
  const title = constants.modules.profit_loss;
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
        {
          {
            mapping: (
              <MappingMode year={year} setYear={setYear} yearSelectItems={yearSelectItems} />
            ),
            view: (
              <ViewMode title={title}>
                <ProfitLossView />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default ProfitLoss;
