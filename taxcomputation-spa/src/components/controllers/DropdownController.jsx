import React from "react";
import { Dropdown } from "primereact/dropdown";

const DropdownController = ({
  Controller,
  control,
  errors,
  controllerName,
  label,
  width,
  required,
  otherRules,
  dropdownOptions,
  placeholder,
  onChangeCallback,
  errorMessage = "",
  defaultValue = ""
}) => {
  return (
    <div className="p-d-flex p-flex-column">
      {label && <p style={{ marginBottom: 5, marginTop: 0 }}>{label}</p>}
      <Controller
        name={controllerName}
        control={control}
        rules={{ required, ...otherRules }}
        defaultValue={defaultValue}
        render={props => (
          <Dropdown
            style={{ marginBottom: 5, width: width || 200 }}
            value={props.value}
            options={dropdownOptions}
            placeholder={placeholder}
            onChange={e => {
              props.onChange(e.target.value);
              if (onChangeCallback) onChangeCallback(e.target.value);
            }}
          />
        )}
      />
      {errors[controllerName] && <span style={{ fontSize: 12, color: "red" }}>{errorMessage}</span>}
    </div>
  );
};

export default DropdownController;
