import React from "react";
import Layout from "../components/layout";
import MinimumTaxView from "../components/minimum_tax/MinimumTaxView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam } from "react-resource-router";
import { Toast } from "primereact/toast";

const MinimumTax = () => {
  const title = constants.modules.minimumTax;
  const toast = React.useRef();
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [percentageTurnOver, setPercentageTurnOver] = React.useState({
    value: "",
    canQuery: false
  });
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
        percentageTurnOver={percentageTurnOver}
        setPercentageTurnOver={setPercentageTurnOver}
        yearSelectItems={yearSelectItems}>
        <ViewMode title={title} year={year}>
          <MinimumTaxView
            year={year}
            toast={toast.current}
            percentageTurnOver={percentageTurnOver}
          />
        </ViewMode>
      </Main>
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default MinimumTax;
