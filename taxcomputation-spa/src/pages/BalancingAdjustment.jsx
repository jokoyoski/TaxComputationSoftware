import React from "react";
import Layout from "../components/layout";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import BalancingAdjustmentView from "../components/balancing_adjustment/BalancingAdjustmentView";
import Main from "../components/layout/Main";
import utils from "../utils";
import { usePathParam, useResource } from "react-resource-router";
import { Toast } from "primereact/toast";
import BalancingAdjustmentAdding from "../components/balancing_adjustment/BalancingAdjustmentAdding";
import { fixedAssetModuleClassResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";

const BalancingAdjustment = () => {
  const title = constants.modules.balancingAdjustment;
  const toast = React.useRef();
  const { data: assetClass, error: assetClassError, refresh: assetClassRefresh } = useResource(
    fixedAssetModuleClassResource
  );
  const [mode, setMode] = usePathParam("mode");
  const [resources, { onFixedAssetModuleItems }] = useResources();
  const [assetClassSelectItems, setAssetClassSelectItems] = React.useState([]);
  const [year, setYear] = React.useState(utils.currentYear());
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

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
      <Main
        title={title}
        mode={mode}
        setMode={setMode}
        year={year}
        setYear={setYear}
        yearSelectItems={yearSelectItems}>
        {
          {
            adding: (
              <BalancingAdjustmentAdding
                yearSelectItems={yearSelectItems}
                assetClassSelectItems={assetClassSelectItems}
                toast={toast.current}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <BalancingAdjustmentView year={year} toast={toast.current} />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default BalancingAdjustment;
