import React from "react";
import { Button } from "primereact/button";
import { useCompany } from "../../store/CompanyStore";
import { useRouterActions } from "react-resource-router";
import constants from "../../constants";

const Header = ({ title }) => {
  const { replace } = useRouterActions();
  const [showSettings, setShowSettings] = React.useState();
  const [{ companyName }, { resetCompany }] = useCompany();

  const onSwitchCompany = () => {
    setShowSettings(false);
    resetCompany();
    replace(constants.routes.dashboard);
  };

  return (
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
                width: 160,
                padding: 5,
                background: "#fff"
              }}>
              <p
                className="settings-item"
                style={{ padding: "5px", margin: 0, textAlign: "right" }}
                onClick={onSwitchCompany}>
                Switch Company
              </p>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default Header;
