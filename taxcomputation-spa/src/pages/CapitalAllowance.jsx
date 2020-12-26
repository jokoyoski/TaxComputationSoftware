import React from "react";
import Layout from "../components/layout";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import CapitalAllowanceView from "../components/capital_allowance/CapitalAllowanceView";
import Main from "../components/layout/Main";
import utils from "../utils";
import CapitalAllowanceAdding from "../components/capital_allowance/CapitalAllowanceAdding";
import { fixedAssetModuleClassResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import { usePathParam, useResource } from "react-resource-router";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";
import CapitalAllowanceSummary from "../components/capital_allowance/CapitalAllowanceSummary";

const CapitalAllowance = ({ toast }) => {
  const title = constants.modules.capitalAllowance;
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
    if (resources.fixedAssetModuleItems) {
      setAssetClassSelectItems(
        resources.fixedAssetModuleItems.map(({ id: assetClassId, name }) => ({
          label: name,
          value: assetClassId
        }))
      );
      setAssetId(resources.fixedAssetModuleItems[0].id);
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
                toast={toast}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <CapitalAllowanceView assetId={assetId} toast={toast} />
              </ViewMode>
            ),
            summary: (
              <ViewMode title={title} year={year}>
                <CapitalAllowanceSummary />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default CapitalAllowance;
