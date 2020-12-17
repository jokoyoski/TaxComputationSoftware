import React from "react";
import { Dropdown } from "primereact/dropdown";
import constants from "../../constants";

const ModuleHeader = ({
  title,
  mode,
  setMode,
  year,
  setYear,
  assetId,
  setAssetId,
  yearSelectItems,
  assetClassSelectItems
}) => {
  const [addingModules] = React.useState([
    constants.modules.balancingAdjustment,
    constants.modules.capitalAllowance
  ]);
  const [summaryModules] = React.useState([constants.modules.capitalAllowance]);
  const [modeSelectItems, setModeSelectItems] = React.useState([
    addingModules.includes(title)
      ? {
          label: "Adding - Mode",
          value: "adding"
        }
      : { label: "Mapping - Mode", value: "mapping" },
    { label: "View - Mode", value: "view" }
  ]);

  React.useEffect(() => {
    setModeSelectItems(state =>
      summaryModules.includes(title)
        ? state.concat([{ label: "Summary - Mode", value: "summary" }])
        : state
    );
  }, [summaryModules, title]);

  return (
    <div className="p-d-flex p-jc-center p-flex-column" style={{ width: "100%" }}>
      <div className="p-d-flex p-ai-center p-jc-between" style={{ padding: "0px 20px" }}>
        <p style={{ fontSize: 18, fontWeight: 600 }}>
          {title}
          {
            {
              adding: " - Adding",
              mapping: " - Mapping",
              view: " - View",
              summary: " - Summary"
            }[mode]
          }
        </p>
        <div>
          {mode === "view" ? (
            title !== constants.modules.capitalAllowance ? (
              <Dropdown
                style={{ width: 180, marginRight: 20 }}
                placeholder="Select year"
                value={year}
                options={yearSelectItems}
                onChange={e => {
                  setYear(e.value);
                }}
              />
            ) : (
              <>
                {assetId && (
                  <Dropdown
                    style={{ width: 180, marginRight: 20 }}
                    placeholder="Select asset"
                    value={assetId}
                    options={assetClassSelectItems}
                    onChange={e => {
                      setAssetId(e.value);
                    }}
                  />
                )}
              </>
            )
          ) : null}
          <Dropdown
            style={{ width: 180 }}
            value={mode}
            disabled={constants.nonMappedModules.includes(title)}
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
