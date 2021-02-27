import React from "react";
import AddEditCompanyForm from "../components/common/AddEditCompanyForm";
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
  const [toast, setToast] = React.useState(null);
  const { data: companies, error, refresh } = useResource(companiesResource);
  const [showCompanyPicker, setShowCompanyPicker] = React.useState(true);
  const [showAddEditCompany, setShowAddEditCompany] = React.useState(false);
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
  }, [company, onFinancialYear, resources.financialYears, toast]);

  React.useEffect(() => {
    if (resources.financialYears?.length > 0) setShowFinancialYear(true);
  }, [resources.financialYears]);

  React.useEffect(() => {
    if (!showAddEditCompany) {
      setShowCompanyPicker(true);
    }
  }, [showAddEditCompany]);

  React.useEffect(() => {
    if (companies) onCompanies(companies);
  }, [companies, onCompanies]);

  React.useEffect(() => {
    if (resources.companies) {
      setCompanySelectItems(
        resources.companies.map(
          ({
            id: companyId,
            companyName,
            companyDescription,
            cacNumber,
            tinNumber,
            isActive,
            minimumTaxTypeId
          }) =>
            isActive && {
              name: companyName,
              value: {
                companyId,
                companyName,
                companyDescription,
                cacNumber,
                tinNumber,
                minimumTaxTypeId
              }
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
        toast={toast}
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
      <AddEditCompanyForm
        showAddEditCompany={showAddEditCompany}
        setShowAddEditCompany={setShowAddEditCompany}
        toast={toast}
        refresh={refresh}
      />
      {company.companyId === null && (
        <CompanyPicker
          setShowAddEditCompany={setShowAddEditCompany}
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
      <Toast baseZIndex={1000} ref={el => setToast(el)} />
    </Layout>
  );
};

export default Dashboard;
