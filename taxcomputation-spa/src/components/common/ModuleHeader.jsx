import React from "react";
import { Dropdown } from "primereact/dropdown";

const ModuleHeader = ({ title, mode, setMode, year, setYear, yearSelectItems }) => {
  const modeSelectItems = [
    { label: "Mapping - Mode", value: "mapping" },
    { label: "View - Mode", value: "view" }
  ];

  return (
    <div className="p-d-flex p-jc-center p-flex-column" style={{ width: "100%" }}>
      <div className="p-d-flex p-ai-center p-jc-between" style={{ padding: "0px 20px" }}>
        <p style={{ fontSize: 18, fontWeight: 600 }}>
          {title} - {{ mapping: "Mapping", view: "View" }[mode]}
        </p>
        <div>
          {mode === "view" && (
            <Dropdown
              style={{ width: 180, marginRight: 20 }}
              placeholder="Select year"
              value={year}
              options={yearSelectItems}
              onChange={e => {
                setYear(e.value);
              }}
            />
          )}
          <Dropdown
            style={{ width: 180 }}
            value={mode}
            options={modeSelectItems}
            onChange={e => {
              setMode(e.value);
            }}
          />
        </div>
      </div>
      <div className="divider"></div>
    </div>
  );
};

export default ModuleHeader;
