import React from "react";
import Layout from "../components/layout";
import IncomeTaxView from "../components/income_tax/IncomeTaxView";
import MappingMode from "../components/common/MappingMode";
import ViewMode from "../components/common/ViewMode";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam } from "react-resource-router";
import constants from "../constants";
import { Toast } from "primereact/toast";

const IncomeTax = () => {
  const title = constants.modules.incomeTax;
  const toast = React.useRef();
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
                <IncomeTaxView year={year} toast={toast.current} />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default IncomeTax;
