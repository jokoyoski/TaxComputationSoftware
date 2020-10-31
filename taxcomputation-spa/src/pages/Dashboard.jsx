import React from "react";
import AddCompanyForm from "../components/dashboard/AddCompanyForm";
import FileUploader from "../components/dashboard/FileUploader";
import Layout from "../components/layout/index";
import TrialBalanceTable from "../components/dashboard/TrialBalanceTable";
import CompanyPicker from "../components/dashboard/CompanyPicker";
import { useResource } from "react-resource-router";
import { companiesResource } from "../routes/resources";
import Loader from "../components/common/Loader";
import constants from "../constants";
import Error from "../components/common/Error";
import { useCompany } from "../store/CompanyStore";
import { Toast } from "primereact/toast";
import { useResources } from "../store/ResourcesStore";

const Dashboard = () => {
  const title = constants.modules.dashboard;
  const toast = React.useRef();
  const { data: companies, error, refresh } = useResource(companiesResource);
  const [showCompanyPicker, setShowCompanyPicker] = React.useState(true);
  const [showAddCompany, setShowAddCompany] = React.useState(false);
  const [companySelectItems, setCompanySelectItems] = React.useState(null);
  const [refreshTrialBalanceTable, setRefreshTrialBalanceTable] = React.useState(true);
  const [company, { onSelectCompany }] = useCompany();
  const [resources, { onCompanies }] = useResources();

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
    if (!showAddCompany) {
      setShowCompanyPicker(true);
    }
  }, [showAddCompany]);

  React.useEffect(() => {
    if (companies) onCompanies(companies);
  }, [companies, onCompanies]);

  React.useEffect(() => {
    if (resources.companies) {
      setCompanySelectItems(
        resources.companies.map(
          ({ id: companyId, companyName, companyDescription, cacNumber, tinNumber, isActive }) =>
            isActive && {
              name: companyName,
              value: { companyId, companyName, companyDescription, cacNumber, tinNumber }
            }
        )
      );
    }
  }, [resources.companies]);

  if (error) return <Error title={title} error={error} refresh={refresh} />;

  if (!resources.companies) return <Loader title={title} />;

  return (
    <Layout title={title}>
      <FileUploader
        company={company}
        toast={toast.current}
        toastCallback={toastCallback}
        setRefreshTrialBalanceTable={setRefreshTrialBalanceTable}
      />
      {company.companyId && (
        <TrialBalanceTable
          company={company}
          refreshTrialBalanceTable={refreshTrialBalanceTable}
          setRefreshTrialBalanceTable={setRefreshTrialBalanceTable}
        />
      )}
      <AddCompanyForm
        showAddCompany={showAddCompany}
        setShowAddCompany={setShowAddCompany}
        toast={toast.current}
        toastCallback={toastCallback}
        refresh={refresh}
      />
      {company.companyId === null && (
        <CompanyPicker
          setShowAddCompany={setShowAddCompany}
          showCompanyPicker={showCompanyPicker}
          setShowCompanyPicker={setShowCompanyPicker}
          company={company}
          onSelectCompany={onSelectCompany}
          companySelectItems={companySelectItems}
          setRefreshTrialBalanceTable={setRefreshTrialBalanceTable}
        />
      )}
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default Dashboard;
