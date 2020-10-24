import React from "react";
import { InputText } from "primereact/inputtext";

const PasswordInput = ({ placeholder, value, onChange }) => {
  const [passwordReveal, setPasswordReveal] = React.useState(false);

  return (
    <div style={{ position: "relative" }}>
      <InputText
        style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
        type={passwordReveal ? "text" : "password"}
        placeholder={placeholder}
        value={value}
        onChange={onChange}
      />
      <i
        className={passwordReveal ? "pi pi-eye-slash" : "pi pi-eye"}
        style={{
          position: "absolute",
          left: "auto",
          right: 10,
          top: 12.5
        }}
        onClick={() => setPasswordReveal(!passwordReveal)}></i>
    </div>
  );
};

export default PasswordInput;
