import React from "react";
import Layout from "../components/layout";
import ProfitAndLossView from "../components/profit_loss/ProfitAndLossView";
import ViewMode from "../components/common/ViewMode";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam, useResource } from "react-resource-router";
import constants from "../constants";
import { profitandlossModuleClassResource, trialBalanceResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";
import { Toast } from "primereact/toast";
import ProfitAndLossMapping from "../components/profit_loss/ProfitAndLossMapping";

const ProfitAndLoss = () => {
  const title = constants.modules.profit_loss;
  const [toast, setToast] = React.useState(null);
  const { data: assetClass, error: assetClassError, refresh: assetClassRefresh } = useResource(
    profitandlossModuleClassResource
  );
  const {
    data: trialBalance,
    error: trialBalanceError,
    refresh: trialBalanceRefresh
  } = useResource(trialBalanceResource);
  const [tbData, setTbData] = React.useState([]);
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [assetClassSelectItems, setAssetClassSelectItems] = React.useState([]);
  const [resources, { onTrialBalance, onProfitAndLossModuleItems }] = useResources();

  React.useEffect(() => {
    if (assetClass) onProfitAndLossModuleItems(assetClass);
  }, [assetClass, onProfitAndLossModuleItems]);

  React.useEffect(() => {
    if (resources.profitAndLossModuleItems) {
      setAssetClassSelectItems(
        resources.profitAndLossModuleItems.map(({ id: assetClassId, name }) => ({
          label: name,
          value: assetClassId
        }))
      );
    }
  }, [resources.profitAndLossModuleItems]);

  React.useEffect(() => {
    if (trialBalance) onTrialBalance(trialBalance);
  }, [onTrialBalance, trialBalance]);

  React.useEffect(() => {
    utils.onTbData(resources, setTbData);
  }, [resources]);

  if (assetClassError)
    return <Error title={title} error={assetClassError} refresh={assetClassRefresh} />;

  if (trialBalanceError)
    return <Error title={title} error={trialBalanceError} refresh={trialBalanceRefresh} />;

  if (!resources.profitAndLossModuleItems || !resources.trialBalance)
    return <PageLoader title={title} />;

  return (
    <Layout title={title}>
      <Main title={title} mode={mode} setMode={setMode} year={year} setYear={setYear}>
        {
          {
            mapping: (
              <ProfitAndLossMapping
                assetClassSelectItems={assetClassSelectItems}
                tbData={tbData}
                onTrialBalance={onTrialBalance}
                trialBalanceRefresh={trialBalanceRefresh}
                toast={toast}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <ProfitAndLossView year={year} toast={toast} />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
      <Toast baseZIndex={1000} ref={el => setToast(el)} />
    </Layout>
  );
};

export default ProfitAndLoss;
