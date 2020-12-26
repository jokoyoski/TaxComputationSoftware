import React from "react";
import Layout from "../components/layout";
import DeferredTaxView from "../components/deferred_tax/DeferredTaxView";
import constants from "../constants";
import ViewMode from "../components/common/ViewMode";
import Main from "../components/layout/Main";
import utils from "../utils";
import { usePathParam, useResource } from "react-resource-router";
import DeferredTaxMapping from "../components/deferred_tax/DeferredTaxMapping";
import { trialBalanceResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";

const DeferredTax = ({ toast }) => {
  const title = constants.modules.deferredTax;
  const {
    data: trialBalance,
    error: trialBalanceError,
    refresh: trialBalanceRefresh
  } = useResource(trialBalanceResource);
  const [tbData, setTbData] = React.useState([]);
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [resources, { onTrialBalance }] = useResources();
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

  React.useEffect(() => {
    if (trialBalance) onTrialBalance(trialBalance);
  }, [onTrialBalance, trialBalance]);

  React.useEffect(() => {
    utils.onTbData(resources, setTbData);
  }, [resources]);

  if (trialBalanceError)
    return <Error title={title} error={trialBalanceError} refresh={trialBalanceRefresh} />;

  if (!resources.trialBalance) return <PageLoader title={title} />;

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
              <DeferredTaxMapping
                tbData={tbData}
                yearSelectItems={yearSelectItems}
                onTrialBalance={onTrialBalance}
                trialBalanceRefresh={trialBalanceRefresh}
                toast={toast}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
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
