import React from "react";
import { Dropdown } from "primereact/dropdown";
import { InputSwitch } from "primereact/inputswitch";
import constants from "../../constants";
import { useResources } from "../../store/ResourcesStore";

const ModuleHeader = ({
  title,
  mode,
  setMode,
  year,
  setYear,
  showITLevy,
  setShowITLevy,
  assetId,
  setAssetId,
  assetClassSelectItems
}) => {
  const [addingModules] = React.useState([
    constants.modules.balancingAdjustment,
    constants.modules.capitalAllowance
  ]);
  const [{ financialYears }] = useResources();
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
        <div className="p-d-flex p-ai-center">
          {mode === "view" && title === constants.modules.incomeTax && (
            <div className="p-d-flex p-ai-center">
              <span>Show IT Levy</span>
              <InputSwitch
                style={{ marginLeft: 10 }}
                checked={showITLevy}
                onChange={e => setShowITLevy(e.value)}
              />
            </div>
          )}
          {mode === "view" ? (
            title !== constants.modules.capitalAllowance ? (
              <Dropdown
                style={{ width: 180, marginLeft: 20 }}
                placeholder="Select year"
                value={year}
                options={financialYears}
                onChange={e => {
                  setYear(e.value);
                }}
              />
            ) : (
              <>
                {assetId && (
                  <Dropdown
                    style={{ width: 180, marginLeft: 20 }}
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
            style={{ width: 180, marginLeft: 20 }}
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
