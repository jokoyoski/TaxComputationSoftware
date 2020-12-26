import React from "react";
import Layout from "../components/layout";
import IncomeTaxView from "../components/income_tax/IncomeTaxView";
import ViewMode from "../components/common/ViewMode";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam, useResource } from "react-resource-router";
import constants from "../constants";
import IncomeTaxMapping from "../components/income_tax/IncomeTaxMapping";
import { trialBalanceResource } from "../routes/resources";
import { useResources } from "../store/ResourcesStore";
import PageLoader from "../components/common/PageLoader";
import Error from "../components/common/Error";

const IncomeTax = ({ toast }) => {
  const title = constants.modules.incomeTax;
  const {
    data: trialBalance,
    error: trialBalanceError,
    refresh: trialBalanceRefresh
  } = useResource(trialBalanceResource);
  const [tbData, setTbData] = React.useState([]);
  const [showITLevy, setShowITLevy] = React.useState(false);
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const [resources, { onTrialBalance }] = useResources();
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

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
        showITLevy={showITLevy}
        setShowITLevy={setShowITLevy}
        yearSelectItems={yearSelectItems}>
        {
          {
            mapping: (
              <IncomeTaxMapping
                tbData={tbData}
                yearSelectItems={yearSelectItems}
                onTrialBalance={onTrialBalance}
                trialBalanceRefresh={trialBalanceRefresh}
                toast={toast}
              />
            ),
            view: (
              <ViewMode title={title} year={year}>
                <IncomeTaxView year={year} toast={toast} showITLevy={showITLevy} />
              </ViewMode>
            )
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default IncomeTax;
