import React from "react";
import { InputText } from "primereact/inputtext";

const PasswordInput = ({ placeholder, autoComplete, value, onChange }) => {
  const [passwordReveal, setPasswordReveal] = React.useState(false);

  React.useEffect(() => setPasswordReveal(state => (!value ? false : state)), [value]);

  return (
    <div style={{ position: "relative" }}>
      <InputText
        style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
        type={passwordReveal ? "text" : "password"}
        autoComplete={autoComplete}
        placeholder={placeholder}
        value={value}
        onChange={onChange}
      />
      {value && (
        <i
          className={passwordReveal ? "pi pi-eye-slash" : "pi pi-eye"}
          style={{
            position: "absolute",
            left: "auto",
            right: 10,
            top: 12.5
          }}
          onClick={() => setPasswordReveal(!passwordReveal)}></i>
      )}
    </div>
  );
};

export default PasswordInput;
