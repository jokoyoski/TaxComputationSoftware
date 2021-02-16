import React from "react";
import Layout from "../components/layout";
import DeferredTaxView from "../components/deferred_tax/DeferredTaxView";
import constants from "../constants";
import ViewMode from "../components/common/ViewMode";
import Main from "../components/layout/Main";
import utils from "../utils";
import { usePathParam, useQueryParam, useResource } from "react-resource-router";
import DeferredTaxMapping from "../components/deferred_tax/DeferredTaxMapping";
import { trialBalanceResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";
import { Toast } from "primereact/toast";

const DeferredTax = () => {
  const title = constants.modules.deferredTax;
  const [toast, setToast] = React.useState(null);
  const {
    data: trialBalance,
    error: trialBalanceError,
    refresh: trialBalanceRefresh
  } = useResource(trialBalanceResource);
  const [tbData, setTbData] = React.useState([]);
  const [isBringDeferredTaxFoward, setIsBringDeferredTaxFoward] = useQueryParam(
    "isBringDeferredTaxFoward"
  );
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [resources, { onTrialBalance }] = useResources();

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
        isBringDeferredTaxFoward={JSON.parse(isBringDeferredTaxFoward || false)}
        setIsBringDeferredTaxFoward={setIsBringDeferredTaxFoward}>
        {
          {
            mapping: (
              <DeferredTaxMapping
                tbData={tbData}
                onTrialBalance={onTrialBalance}
                trialBalanceRefresh={trialBalanceRefresh}
                toast={toast}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <DeferredTaxView
                  year={year}
                  toast={toast}
                  isBringDeferredTaxFoward={JSON.parse(isBringDeferredTaxFoward || false)}
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

export default DeferredTax;
