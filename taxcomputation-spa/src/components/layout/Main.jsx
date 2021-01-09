import React from "react";
import { Card } from "primereact/card";
import ModuleHeader from "../common/ModuleHeader";
import constants from "../../constants";
import utils from "../../utils";

const Main = ({
  title,
  mode,
  setMode,
  year,
  setYear,
  showITLevy,
  setShowITLevy,
  assetId,
  setAssetId,
  assetClassSelectItems,
  children
}) => {
  if (!constants.modes.includes(mode)) setMode(utils.defaultMode(title));

  return (
    <Card
      header={
        <ModuleHeader
          title={title}
          mode={mode}
          setMode={setMode}
          year={year}
          setYear={setYear}
          showITLevy={showITLevy}
          setShowITLevy={setShowITLevy}
          assetId={assetId}
          setAssetId={setAssetId}
          assetClassSelectItems={assetClassSelectItems}
        />
      }
      style={{ width: "100%", overflowX: "auto" }}>
      {children}
    </Card>
  );
};

export default Main;
