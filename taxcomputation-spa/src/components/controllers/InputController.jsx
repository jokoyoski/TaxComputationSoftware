import React from "react";
import { InputText } from "primereact/inputtext";
import { InputNumber } from "primereact/inputnumber";

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
  onChangeCallback,
  labelWidth,
  errorMessage = "",
  defaultValue = "",
  type = "text",
  className = "p-d-flex p-flex-column"
}) => {
  const inputProps = ({ type, disabled, props, placeholder, onChangeCallback }) => {
    const inputPropsObj = {
      disabled,
      value: props.value,
      placeholder,
      onChange:
        type === "text"
          ? e => {
              props.onChange(e.target.value);
              if (onChangeCallback) onChangeCallback(e.target.value);
            }
          : null
    };

    if (type === "number") {
      inputPropsObj.onValueChange = e => {
        props.onChange(e.value);
        if (onChangeCallback) onChangeCallback(e.value);
      };
    }
    return inputPropsObj;
  };

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
          defaultValue={type === "number" ? (defaultValue === "" ? 0 : defaultValue) : defaultValue}
          render={props =>
            type === "number" ? (
              <InputNumber
                {...inputProps({ type, disabled, props, placeholder, onChangeCallback })}
                style={{
                  marginBottom:
                    !errors[controllerName] || className === "p-d-flex p-flex-column" ? 5 : 0,
                  width: width || 200
                }}
              />
            ) : (
              <InputText
                {...inputProps({ type, disabled, props, placeholder, onChangeCallback })}
                style={{
                  marginBottom:
                    !errors[controllerName] || className === "p-d-flex p-flex-column" ? 5 : 0,
                  width: width || 200
                }}
              />
            )
          }
        />
        {className === "p-d-flex p-flex-column" && <ControllerError />}
      </div>
      {className !== "p-d-flex p-flex-column" && <ControllerError />}
    </>
  );
};

export default InputController;
