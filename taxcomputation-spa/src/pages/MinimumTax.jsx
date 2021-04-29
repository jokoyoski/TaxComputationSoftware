import React from "react";
import Layout from "../components/layout";
import MinimumTaxView from "../components/minimum_tax/MinimumTaxView";
import MinimumTaxMapping from "../components/minimum_tax/MinimumTaxMapping";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam, useQueryParam } from "react-resource-router";
import { Toast } from "primereact/toast";

const MinimumTax = () => {
  const title = constants.modules.minimumTax;
  const [toast, setToast] = React.useState(null);
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
    if (percentageTurnOverValue && !percentageTurnOver.canQuery) {
      setPercentageTurnOver(state => ({ ...state, canQuery: true }));
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  React.useEffect(() => {
    if (!percentageTurnOver.canQuery) {
      if (percentageTurnOverValue) return;
      setPercentageTurnOverValue(undefined);
    } else setPercentageTurnOverValue(percentageTurnOver.value);
  }, [
    percentageTurnOver.canQuery,
    percentageTurnOver.value,
    percentageTurnOverValue,
    setPercentageTurnOverValue
  ]);

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
        {
          {
            mapping: <MinimumTaxMapping toast={toast} />,
            view: (
              <ViewMode title={title} year={year}>
                <MinimumTaxView
                  year={year}
                  toast={toast}
                  percentageTurnOver={percentageTurnOver}
                  setPercentageTurnOver={setPercentageTurnOver}
                  setPercentageTurnOverValue={setPercentageTurnOverValue}
                />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
      <Toast baseZIndex={1000} ref={el => setToast(el)} />
    </Layout>
  );
};

export default MinimumTax;
