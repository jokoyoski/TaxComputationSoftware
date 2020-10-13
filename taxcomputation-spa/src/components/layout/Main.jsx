import React from "react";
import { Card } from "primereact/card";
import ModuleHeader from "../common/ModuleHeader";

const Main = ({ title, mode, setMode, year, setYear, yearSelectItems, children }) => {
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
