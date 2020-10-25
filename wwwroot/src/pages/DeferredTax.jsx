import React from "react";
import Layout from "../components/layout";
import MappingMode from "../components/common/MappingMode";
import DeferredTaxView from "../components/deferred_tax/DeferredTaxView";
import constants from "../constants";
import ViewMode from "../components/common/ViewMode";
import Main from "../components/layout/Main";
import utils from "../utils";
import { usePathParam } from "react-resource-router";

const DeferredTax = () => {
  const title = constants.modules.deferredTax;
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
                <DeferredTaxView />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default DeferredTax;