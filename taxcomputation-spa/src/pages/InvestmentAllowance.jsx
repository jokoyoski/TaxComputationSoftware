import React from "react";
import Layout from "../components/layout";
import InvestmentAllowanceView from "../components/investment_allowance/InvestmentAllowanceView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import Main from "../components/layout/Main";
import utils from "../utils";
import { Toast } from "primereact/toast";
import { usePathParam, useResource } from "react-resource-router";
import InvestmentAllowanceMapping from "../components/investment_allowance/InvestmentAllowanceMapping";
import { fixedAssetModuleClassResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";

const InvestmentAllowance = () => {
  const title = constants.modules.investmentAllowance;
  const toast = React.useRef();
  const { data: assetClass, error: assetClassError, refresh: assetClassRefresh } = useResource(
    fixedAssetModuleClassResource
  );
  const [resources, { onFixedAssetModuleItems }] = useResources();
  const [assetClassSelectItems, setAssetClassSelectItems] = React.useState([]);
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());

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

  if (assetClassError)
    return <Error title={title} error={assetClassError} refresh={assetClassRefresh} />;

  if (!resources.fixedAssetModuleItems) return <PageLoader title={title} />;

  return (
    <Layout title={title}>
      <Main title={title} mode={mode} setMode={setMode} year={year} setYear={setYear}>
        {
          {
            mapping: (
              <InvestmentAllowanceMapping
                assetClassSelectItems={assetClassSelectItems}
                toast={toast.current}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <InvestmentAllowanceView year={year} toast={toast.current} />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default InvestmentAllowance;
