import React from "react";
import Layout from "../components/layout";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import CapitalAllowanceView from "../components/capital_allowance/CapitalAllowanceView";
import Main from "../components/layout/Main";
import utils from "../utils";
import CapitalAllowanceAdding from "../components/capital_allowance/CapitalAllowanceAdding";
import { Toast } from "primereact/toast";
import { fixedAssetModuleClassResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import { usePathParam, useResource } from "react-resource-router";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";

const CapitalAllowance = () => {
  const title = constants.modules.capitalAllowance;
  const toast = React.useRef();
  const { data: assetClass, error: assetClassError, refresh: assetClassRefresh } = useResource(
    fixedAssetModuleClassResource
  );
  const [resources, { onFixedAssetModuleItems }] = useResources();
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [assetId, setAssetId] = React.useState();
  const [assetClassSelectItems, setAssetClassSelectItems] = React.useState([]);
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

  React.useEffect(() => {
    if (assetClass) onFixedAssetModuleItems(assetClass);
  }, [assetClass, onFixedAssetModuleItems]);

  React.useEffect(() => {
    if (resources.moduleItems) {
      setAssetClassSelectItems(
        resources.moduleItems.map(({ id: assetClassId, name }) => ({
          label: name,
          value: assetClassId
        }))
      );
      setAssetId(resources.moduleItems[0].id);
    }
  }, [resources.moduleItems]);

  if (assetClassError)
    return <Error title={title} error={assetClassError} refresh={assetClassRefresh} />;

  if (!resources.moduleItems) return <PageLoader title={title} />;

  return (
    <Layout title={title}>
      <Main
        title={title}
        mode={mode}
        setMode={setMode}
        year={year}
        setYear={setYear}
        yearSelectItems={yearSelectItems}
        assetId={assetId}
        setAssetId={setAssetId}
        assetClassSelectItems={assetClassSelectItems}>
        {
          {
            adding: (
              <CapitalAllowanceAdding
                yearSelectItems={yearSelectItems}
                assetClassSelectItems={assetClassSelectItems}
                toast={toast.current}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <CapitalAllowanceView assetId={assetId} />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default CapitalAllowance;
