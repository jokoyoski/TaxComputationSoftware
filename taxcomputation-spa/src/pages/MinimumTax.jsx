import React from "react";
import Layout from "../components/layout";
import MinimumTaxView from "../components/minimum_tax/MinimumTaxView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam, useQueryParam } from "react-resource-router";
import { Toast } from "primereact/toast";

const MinimumTax = () => {
  const title = constants.modules.minimumTax;
  const toast = React.useRef();
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [percentageTurnOverValue, setPercentageTurnOverValue] = useQueryParam("percentageTurnOver");
  const [percentageTurnOver, setPercentageTurnOver] = React.useState({
    value: percentageTurnOverValue || "",
    canQuery: false
  });
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

  React.useEffect(() => {
    if (percentageTurnOver.value === "") setPercentageTurnOverValue(undefined);
    else setPercentageTurnOverValue(percentageTurnOver.value);
  }, [percentageTurnOver.value, setPercentageTurnOverValue]);

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
            setPercentageTurnOver={setPercentageTurnOver}
          />
        </ViewMode>
      </Main>
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default MinimumTax;
