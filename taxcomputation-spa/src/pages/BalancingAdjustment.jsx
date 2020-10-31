import React from "react";
import Layout from "../components/layout";
import MappingMode from "../components/common/MappingMode";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import BalancingAdjustmentView from "../components/balancing_adjustment/BalancingAdjustmentView";
import Main from "../components/layout/Main";
import utils from "../utils";
import { usePathParam } from "react-resource-router";

const BalancingAdjustment = () => {
  const title = constants.modules.balancingAdjustment;
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
              <ViewMode title={title} year={year}>
                <BalancingAdjustmentView />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default BalancingAdjustment;
