import React from "react";
import Layout from "../components/layout";
import InvestmentAllowanceView from "../components/investment_allowance/InvestmentAllowanceView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import Main from "../components/layout/Main";
import utils from "../utils";
import { usePathParam, useResource } from "react-resource-router";
import InvestmentAllowanceMapping from "../components/investment_allowance/InvestmentAllowanceMapping";
import { fixedAssetModuleClassResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";

const InvestmentAllowance = ({ toast }) => {
  const title = constants.modules.investmentAllowance;
  const { data: assetClass, error: assetClassError, refresh: assetClassRefresh } = useResource(
    fixedAssetModuleClassResource
  );
  const [resources, { onFixedAssetModuleItems }] = useResources();
  const [assetClassSelectItems, setAssetClassSelectItems] = React.useState([]);
  const [mode, setMode] = usePathParam("mode");
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
            mapping: (
              <InvestmentAllowanceMapping
                yearSelectItems={yearSelectItems}
                assetClassSelectItems={assetClassSelectItems}
                toast={toast}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <InvestmentAllowanceView year={year} toast={toast} />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default InvestmentAllowance;
