import React from "react";
import { Button } from "primereact/button";
import { useCompany } from "../../store/CompanyStore";
import { useRouterActions } from "react-resource-router";
import constants from "../../constants";
import ChangePassword from "../common/ChangePassword";
import CreateUser from "../common/CreateUser";
import { useResources } from "../../store/ResourcesStore";
import CreateAsset from "../common/CreateAsset";
import AssetList from "../common/AssetList";
import FinancialYear from "../common/FinancialYear";
import CompanyList from "../common/CompanyList";
import CompanyDetails from "../common/CompanyDetails";
import AddEditCompanyForm from "../common/AddEditCompanyForm";
import { Toast } from "primereact/toast";
import utils from "../../utils";
import { rollback, rollover } from "../../apis/Rollover";

const Header = ({ title, loading, setPageLoader }) => {
  const { replace } = useRouterActions();
  const [toast, setToast] = React.useState(null);
  const [showSettings, setShowSettings] = React.useState();
  const [showChangePassword, setShowChangePassword] = React.useState();
  const [showCreateUser, setShowCreateUser] = React.useState();
  const [showCreateAsset, setShowCreateAsset] = React.useState();
  const [showAssetList, setShowAssetList] = React.useState();
  const [showCompanyList, setShowCompanyList] = React.useState();
  const [showCompanyDetails, setShowCompanyDetails] = React.useState();
  const [showAddEditCompany, setShowAddEditCompany] = React.useState();
  const [showFinancialYear, setShowFinancialYear] = React.useState(false);
  const [{ companyName, companyId }, { resetCompany }] = useCompany();
  const [
    { financialYears, selectedFinancialYear, selectedCompany },
    { resetResources }
  ] = useResources();

  const onSwitchCompany = () => {
    setShowSettings(false);
    resetCompany();
    resetResources();
    sessionStorage.removeItem("year");
    replace(constants.routes.home);
  };

  const selectedFinancialYearLabel = React.useMemo(
    () => financialYears?.find(year => year.value === selectedFinancialYear)?.label,
    [financialYears, selectedFinancialYear]
  );

  const reloadPage = () => {
    setPageLoader(false);
    resetCompany();
    resetResources();
    sessionStorage.removeItem("year");
    window.location.reload();
  };

  const rolloverHandler = async () => {
    setShowSettings(false);
    setPageLoader(true);
    try {
      const res = await rollover(companyId);
      if (res.status === 200) reloadPage();
    } catch (error) {
      utils.apiErrorHandling(error, toast);
    }
  };

  const rollbackHandler = async () => {
    setShowSettings(false);
    setPageLoader(true);
    try {
      const res = await rollback(companyId);
      if (res.status === 200) reloadPage();
    } catch (error) {
      utils.apiErrorHandling(error, toast);
    }
  };

  return (
    <>
      <div
        className="p-d-flex p-jc-between p-ai-center drop-shadow"
        style={{
          background: "#fff",
          width: "calc(100% - 256px)",
          height: 66,
          padding: "0px 20px",
          position: "fixed",
          borderLeft: "2px solid #f5f6f8",
          zIndex: 1
        }}>
        <p style={{ marginTop: 5, marginBottom: 0, fontSize: 18, fontWeight: 600 }}>{title}</p>
        {!loading && (
          <div className="p-d-flex p-ai-center">
            {selectedFinancialYear && (
              <p style={{ marginRight: 20 }}>
                {selectedFinancialYearLabel && `Tax Year: ${selectedFinancialYearLabel}`}
              </p>
            )}
            {companyName && <p className="header-company-name">{`Company: ${companyName}`}</p>}
            <div style={{ position: "relative" }}>
              <Button
                icon="pi pi-cog pi-20"
                className="p-button-text"
                onClick={() => setShowSettings(!showSettings)}
              />
              {showSettings && (
                <div
                  className="drop-shadow"
                  style={{
                    position: "absolute",
                    right: 0,
                    width: 170,
                    padding: 5,
                    background: "#fff"
                  }}>
                  <p className="settings-item" onClick={rolloverHandler}>
                    Rollover
                  </p>
                  <p className="settings-item" onClick={rollbackHandler}>
                    Rollback
                  </p>
                  <p
                    className="settings-item"
                    onClick={() => {
                      setShowFinancialYear(true);
                      setShowSettings(false);
                    }}>
                    Tax Year
                  </p>
                  <p
                    className="settings-item"
                    onClick={() => {
                      setShowAssetList(!showAssetList);
                      setShowSettings(false);
                    }}>
                    Asset List
                  </p>
                  <p
                    className="settings-item"
                    onClick={() => {
                      setShowCreateUser(!showCreateUser);
                      setShowSettings(false);
                    }}>
                    Create User
                  </p>
                  <p
                    className="settings-item"
                    onClick={() => {
                      setShowCompanyList(!showCompanyList);
                      setShowSettings(false);
                    }}>
                    Company List
                  </p>
                  <p className="settings-item" onClick={onSwitchCompany}>
                    Switch Company
                  </p>
                  <p
                    className="settings-item"
                    onClick={() => {
                      setShowChangePassword(!showChangePassword);
                      setShowSettings(false);
                    }}>
                    Change Password
                  </p>
                </div>
              )}
            </div>
          </div>
        )}
      </div>
      {showChangePassword && <ChangePassword setShowChangePassword={setShowChangePassword} />}
      {showCreateUser && <CreateUser setShowCreateUser={setShowCreateUser} />}
      {showCreateAsset && (
        <CreateAsset setShowCreateAsset={setShowCreateAsset} setShowAssetList={setShowAssetList} />
      )}
      {showAssetList && (
        <AssetList
          showAssetList={showAssetList}
          setShowAssetList={setShowAssetList}
          setShowCreateAsset={setShowCreateAsset}
        />
      )}
      {showCompanyList && (
        <CompanyList
          showCompanyList={showCompanyList}
          setShowCompanyList={setShowCompanyList}
          setShowCompanyDetails={setShowCompanyDetails}
          setShowAddEditCompany={setShowAddEditCompany}
        />
      )}
      {showCompanyDetails && selectedCompany && (
        <CompanyDetails
          companyId={selectedCompany}
          showCompanyDetails={showCompanyDetails}
          setShowCompanyDetails={setShowCompanyDetails}
          setShowCompanyList={setShowCompanyList}
        />
      )}
      {showAddEditCompany && selectedCompany && (
        <AddEditCompanyForm
          toast={toast}
          companyId={selectedCompany}
          showAddEditCompany={showAddEditCompany}
          setShowAddEditCompany={setShowAddEditCompany}
          setShowCompanyList={setShowCompanyList}
        />
      )}
      {showFinancialYear && (
        <FinancialYear
          showFinancialYear={showFinancialYear}
          setShowFinancialYear={setShowFinancialYear}
          setShowSettings={setShowSettings}
        />
      )}
      <Toast baseZIndex={1000} ref={el => setToast(el)} />
    </>
  );
};

export default Header;
