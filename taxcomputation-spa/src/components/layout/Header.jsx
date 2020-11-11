import React from "react";
import { Button } from "primereact/button";
import { useCompany } from "../../store/CompanyStore";
import { useRouterActions } from "react-resource-router";
import constants from "../../constants";
import ChangePassword from "../common/ChangePassword";
import CreateUser from "../common/CreateUser";
import { useResources } from "../../store/ResourcesStore";

const Header = ({ title, loading }) => {
  const { replace } = useRouterActions();
  const [showSettings, setShowSettings] = React.useState();
  const [showChangePassword, setShowChangePassword] = React.useState();
  const [showCreateUser, setShowCreateUser] = React.useState();
  const [{ companyName }, { resetCompany }] = useCompany();
  const [, { resetResources }] = useResources();

  const onSwitchCompany = () => {
    setShowSettings(false);
    resetCompany();
    resetResources();
    replace(constants.routes.home);
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
            <p style={{ marginRight: 10 }}>{companyName}</p>
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
                  <p
                    className="settings-item"
                    onClick={() => {
                      setShowCreateUser(!showCreateUser);
                      setShowSettings(false);
                    }}>
                    Create User
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
    </>
  );
};

export default Header;
