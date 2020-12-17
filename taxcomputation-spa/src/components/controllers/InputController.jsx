import React from "react";
import { InputText } from "primereact/inputtext";

const InputController = ({
  Controller,
  control,
  errors,
  controllerName,
  label,
  width,
  required,
  disabled,
  otherRules,
  placeholder,
  value,
  onChangeCallback,
  labelWidth,
  errorMessage = "",
  defaultValue = "",
  className = "p-d-flex p-flex-column"
}) => {
  const ControllerError = () => (
    <>
      {errors[controllerName] && (
        <span style={{ fontSize: 12, color: "red", marginLeft: labelWidth ? labelWidth : 0 }}>
          {errorMessage}
        </span>
      )}
    </>
  );

  return (
    <>
      <div className={className}>
        {label && (
          <p
            style={{
              marginBottom:
                !errors[controllerName] || className === "p-d-flex p-flex-column" ? 5 : 0,
              marginTop: 0,
              width: labelWidth ? labelWidth : "auto"
            }}>
            {label}
          </p>
        )}
        <Controller
          name={controllerName}
          control={control}
          rules={{ required, ...otherRules }}
          defaultValue={defaultValue}
          render={props => (
            <InputText
              disabled={disabled}
              style={{
                marginBottom:
                  !errors[controllerName] || className === "p-d-flex p-flex-column" ? 5 : 0,
                width: width || 200
              }}
              value={value || props.value}
              placeholder={placeholder}
              onChange={e => {
                props.onChange(e.target.value);
                if (onChangeCallback) onChangeCallback(e.target.value);
              }}
            />
          )}
        />
        {className === "p-d-flex p-flex-column" && <ControllerError />}
      </div>
      {className !== "p-d-flex p-flex-column" && <ControllerError />}
    </>
  );
};

export default InputController;
