import React from "react";
import ViewMode from "../components/common/ViewMode";
import Layout from "../components/layout";
import Main from "../components/layout/Main";
import constants from "../constants";
import utils from "../utils";
import { usePathParam, useResource } from "react-resource-router";
import FixedAssetMapping from "../components/fixed_asset/FixedAssetMapping";
import { assetClassResource, trialBalanceResource } from "../routes/resources";
import Loader from "../components/common/Loader";
import Error from "../components/common/Error";
import { Toast } from "primereact/toast";

const FixedAsset = () => {
  const title = constants.modules.fixedAsset;
  const toast = React.useRef();
  const {
    data: assetClass,
    loading: assetClassLoading,
    error: assetClassError,
    refresh: assetClassRefresh
  } = useResource(assetClassResource);
  const {
    data: trialBalance,
    loading: trialBalanceLoading,
    error: trialBalanceError,
    refresh: trialBalanceRefresh
  } = useResource(trialBalanceResource);
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [tbData, setTbData] = React.useState([]);
  const [assetClassSelectItems, setAssetClassSelectItems] = React.useState([]);
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

  const toastCallback = React.useCallback(
    ({ severity, summary, detail }) => ({
      severity,
      summary,
      detail,
      life: constants.toastLifeTime,
      closable: false
    }),
    []
  );

  React.useEffect(() => {
    if (assetClass) {
      setAssetClassSelectItems(
        assetClass.map(({ id: assetClassId, name }) => ({
          label: name,
          value: assetClassId
        }))
      );
    }
  }, [assetClass]);

  React.useEffect(() => {
    if (trialBalance) {
      setTbData(
        trialBalance
          ? trialBalance
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
  }, [trialBalance]);

  if (assetClassLoading || trialBalanceLoading) return <Loader title={title} />;

  if (assetClassError)
    return <Error title={title} error={assetClassError} refresh={assetClassRefresh} />;

  if (trialBalanceError)
    return <Error title={title} error={trialBalanceError} refresh={trialBalanceRefresh} />;

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
                toast={toast.current}
                toastCallback={toastCallback}
              />
            ),
            view: <ViewMode title={title}></ViewMode>
          }[mode]
        }
      </Main>
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default FixedAsset;
