import React from "react";
import Layout from "../components/layout";
import MappingMode from "../components/common/MappingMode";
import MinimumTaxView from "../components/minimum_tax/MinimumTaxView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import utils from "../utils";
import Main from "../components/layout/Main";

const MinimumTax = () => {
  const title = constants.modules.minimumTax;
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
                <MinimumTaxView />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default MinimumTax;
