import React from "react";
import AddCompanyForm from "../components/dashboard/AddCompanyForm";
import FileUploader from "../components/dashboard/FileUploader";
import Layout from "../components/layout/index";
import CompanyTable from "../components/dashboard/CompanyTable";
import CompanyPicker from "../components/dashboard/CompanyPicker";

const Dashboard = () => {
  const [showCompanyPicker, setShowCompanyPicker] = React.useState(true);
  const [showAddCompany, setShowAddCompany] = React.useState(false);
  const [company, setCompany] = React.useState();

  React.useEffect(() => {
    if (!showAddCompany) {
      setShowCompanyPicker(true);
    }
  }, [showAddCompany]);

  return (
    <Layout title="Dashboard">
      <FileUploader />
      <CompanyTable setShowAddCompany={setShowAddCompany} />
      <AddCompanyForm showAddCompany={showAddCompany} setShowAddCompany={setShowAddCompany} />
      <CompanyPicker
        setShowAddCompany={setShowAddCompany}
        showCompanyPicker={showCompanyPicker}
        setShowCompanyPicker={setShowCompanyPicker}
        company={company}
        setCompany={setCompany}
      />
    </Layout>
  );
};

export default Dashboard;
