import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Password } from "primereact/password";

const Login = () => {
  const [userName, setUserName] = React.useState();
  const [password, setPassword] = React.useState();

  return (
    <div className="p-d-flex p-jc-center p-ai-center" style={{ height: "100vh" }}>
      <Card
        footer={<Button label="Login" style={{ width: "100%" }} />}
        header={
          <>
            <h2 className="p-text-center accent-color">Tax Computation</h2>
            <div className="divider"></div>
          </>
        }
        style={{ width: 320 }}>
        <div className="p-d-flex p-flex-column">
          <InputText
            style={{ marginBottom: 20 }}
            placeholder="User Name"
            value={userName}
            onChange={e => setUserName(e.target.value)}
          />
          <Password
            placeholder="Password"
            feedback={false}
            value={password}
            onChange={e => setPassword(e.target.value)}
          />
        </div>
      </Card>
    </div>
  );
};

export default Login;
