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
  const [resources, { onTrialBalance, onModuleItems }] = useResources();
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

  React.useEffect(() => {
    if (assetClass) onModuleItems(assetClass);
  }, [assetClass, onModuleItems]);

  React.useEffect(() => {
    if (resources.moduleItems) {
      setAssetClassSelectItems(
        resources.moduleItems.map(({ id: assetClassId, name }) => ({
          label: name,
          value: assetClassId
        }))
      );
    }
  }, [resources.moduleItems]);

  React.useEffect(() => {
    if (trialBalance) onTrialBalance(trialBalance);
  }, [onTrialBalance, trialBalance]);

  React.useEffect(() => {
    if (resources.trialBalance) {
      setTbData(
        resources.trialBalance
          ? resources.trialBalance
              .filter(
                d =>
                  !(d.accountId === "" && d.item === "" && d.debit === 0 && d.credit === 0) &&
                  !d.item.toLowerCase().includes("total")
              )
              .map(d => ({
                ...d,
                debitAmt: utils.currencyFormatter(d.debit),
                creditAmt: utils.currencyFormatter(d.credit)
              }))
          : []
      );
    }
  }, [resources.trialBalance]);

  if (assetClassError)
    return <Error title={title} error={assetClassError} refresh={assetClassRefresh} />;

  if (trialBalanceError)
    return <Error title={title} error={trialBalanceError} refresh={trialBalanceRefresh} />;

  if (!resources.moduleItems || !resources.trialBalance) return <PageLoader title={title} />;

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
              <FixedAssetMapping
                year={year}
                setYear={setYear}
                yearSelectItems={yearSelectItems}
                assetClassSelectItems={assetClassSelectItems}
                tbData={tbData}
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
