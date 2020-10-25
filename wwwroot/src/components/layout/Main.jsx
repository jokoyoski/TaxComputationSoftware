import React from "react";
import { Card } from "primereact/card";
import ModuleHeader from "../common/ModuleHeader";
import constants from "../../constants";
import utils from "../../utils";

const Main = ({ title, mode, setMode, year, setYear, yearSelectItems, children }) => {
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
          yearSelectItems={yearSelectItems}
        />
      }
      style={{ width: "100%" }}>
      {children}
    </Card>
  );
};

export default Main;