import React from "react";
import ViewMode from "../components/common/ViewMode";
import Layout from "../components/layout";
import Main from "../components/layout/Main";
import constants from "../constants";
import utils from "../utils";
import { usePathParam, useResource } from "react-resource-router";
import FixedAssetMapping from "../components/fixed_asset/FixedAssetMapping";
import { fixedAssetModuleClassResource, trialBalanceResource } from "../routes/resources";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";
import { Toast } from "primereact/toast";
import { useResources } from "../store/ResourcesStore";
import FixedAssetView from "../components/fixed_asset/FixedAssetView";

const FixedAsset = () => {
  const title = constants.modules.fixedAsset;
  const toast = React.useRef();
  const { data: assetClass, error: assetClassError, refresh: assetClassRefresh } = useResource(
    fixedAssetModuleClassResource
  );
  const {
    data: trialBalance,
    error: trialBalanceError,
    refresh: trialBalanceRefresh
  } = useResource(trialBalanceResource);
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [tbData, setTbData] = React.useState([]);
  const [assetClassSelectItems, setAssetClassSelectItems] = React.useState([]);
  const [resources, { onTrialBalance, onFixedAssetModuleItems }] = useResources();

  React.useEffect(() => {
    if (assetClass) onFixedAssetModuleItems(assetClass);
  }, [assetClass, onFixedAssetModuleItems]);

  React.useEffect(() => {
    if (resources.fixedAssetModuleItems) {
      setAssetClassSelectItems(
        resources.fixedAssetModuleItems.map(({ id: assetClassId, name }) => ({
          label: name,
          value: assetClassId
        }))
      );
    }
  }, [resources.fixedAssetModuleItems]);

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

  if (!resources.fixedAssetModuleItems || !resources.trialBalance)
    return <PageLoader title={title} />;

  return (
    <Layout title={title}>
      <Main title={title} mode={mode} setMode={setMode} year={year} setYear={setYear}>
        {
          {
            mapping: (
              <FixedAssetMapping
                assetClassSelectItems={assetClassSelectItems}
                tbData={tbData}
                onTrialBalance={onTrialBalance}
                trialBalanceRefresh={trialBalanceRefresh}
                toast={toast.current}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <FixedAssetView year={year} />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default FixedAsset;
