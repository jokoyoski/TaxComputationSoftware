import React from "react";
import AddCompanyForm from "../components/dashboard/AddCompanyForm";
import FileUploader from "../components/dashboard/FileUploader";
import Layout from "../components/layout/index";
import TrialBalanceTable from "../components/dashboard/TrialBalanceTable";
import CompanyPicker from "../components/dashboard/CompanyPicker";
import { useResource } from "react-resource-router";
import { companiesResource } from "../routes/resources";
import PageLoader from "../components/common/PageLoader";
import constants from "../constants";
import Error from "../components/common/Error";
import { useCompany } from "../store/CompanyStore";
import { Toast } from "primereact/toast";
import { useResources } from "../store/ResourcesStore";
import utils from "../utils";
import FinancialYear from "../components/common/FinancialYear";

const Dashboard = () => {
  const title = constants.modules.dashboard;
  const toast = React.useRef();
  const { data: companies, error, refresh } = useResource(companiesResource);
  const [showCompanyPicker, setShowCompanyPicker] = React.useState(true);
  const [showAddCompany, setShowAddCompany] = React.useState(false);
  const [companySelectItems, setCompanySelectItems] = React.useState(null);
  const [showFinancialYear, setShowFinancialYear] = React.useState(false);
  const [loading, setLoading] = React.useState(false);
  const [refreshTrialBalanceTable, setRefreshTrialBalanceTable] = React.useState(true);
  const [company, { onSelectCompany }] = useCompany();
  const [resources, { onCompanies, onFinancialYear }] = useResources();

  React.useEffect(() => {
    if (!resources.financialYears && company.companyId) {
      onFinancialYear([]);
      utils.fetchCompanyFinancialYear(company, onFinancialYear, toast, setLoading);
    }
  }, [company, onFinancialYear, resources.financialYears]);

  React.useEffect(() => {
    if (resources.financialYears?.length > 0) setShowFinancialYear(true);
  }, [resources.financialYears]);

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

  if (!resources.companies || loading) return <PageLoader title={title} activeSidebar={!loading} />;

  return (
    <Layout title={title}>
      <FileUploader
        company={company}
        toast={toast.current}
        setRefreshTrialBalanceTable={setRefreshTrialBalanceTable}
      />
      {company.companyId && (
        <TrialBalanceTable
          company={company}
          toast={toast}
          refreshTrialBalanceTable={refreshTrialBalanceTable}
          setRefreshTrialBalanceTable={setRefreshTrialBalanceTable}
        />
      )}
      <AddCompanyForm
        showAddCompany={showAddCompany}
        setShowAddCompany={setShowAddCompany}
        toast={toast.current}
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
      {showFinancialYear && !sessionStorage.getItem("year") && (
        <FinancialYear
          showFinancialYear={showFinancialYear}
          setShowFinancialYear={setShowFinancialYear}
        />
      )}
      <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
    </Layout>
  );
};

export default Dashboard;
