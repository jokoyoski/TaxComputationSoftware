import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Toast } from "primereact/toast";
import { useForm, Controller } from "react-hook-form";
import { forgotPassword } from "../apis/Authentication";
import constants from "../constants";
import { useAuth } from "../store/AuthStore";
import { Link, Redirect, useRouterActions } from "react-resource-router";
import utils from "../utils";

const ForgotPassword = () => {
  const { errors, handleSubmit, control } = useForm();
  const [{ isAuthenticated }] = useAuth();
  const { push } = useRouterActions();
  const [loading, setLoading] = React.useState(false);
  const toast = React.useRef();

  const onSubmit = async data => {
    if (loading) return;

    setLoading(true);
    const { email } = data;
    try {
      const message = await forgotPassword({ email });
      push({ pathname: constants.routes.reset_password, state: message });
    } catch (error) {
      setLoading(false);
      if (error.response) {
        const {
          data: { message }
        } = error.response;
        // display error as toast notification
        toast.current.show(
          utils.toastCallback({ severity: "error", summary: "Error", detail: message })
        );
      } else {
        // network errors
        toast.current.show(
          utils.toastCallback({
            severity: "error",
            summary: "Network Error",
            detail: constants.networkErrorMessage
          })
        );
      }
    }
  };

  if (isAuthenticated) {
    const path = sessionStorage.getItem("path") || constants.routes.dashboard;
    sessionStorage.removeItem("path");
    return <Redirect to={path} />;
  }

  return (
    <div className="p-d-flex p-jc-center p-ai-center" style={{ height: "100vh" }}>
      <Card
        header={
          <>
            <h2 className="p-text-center accent-color">Tax Computation</h2>
            <div className="divider"></div>
          </>
        }
        style={{ width: 320 }}>
        <form className="p-d-flex p-flex-column" onSubmit={handleSubmit(onSubmit)}>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="email"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%" }}
                  placeholder="Email"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.email && <span style={{ fontSize: 12, color: "red" }}>Email is required</span>}
          </div>
          <Button
            type="submit"
            label={!loading ? "Forgot Password" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: "100%" }}
          />
        </form>
        <Link href={constants.routes.login} className="auth-link">
          <p style={{ marginBottom: 0, marginTop: 20, fontSize: 14 }}>Back to login</p>
        </Link>
      </Card>
      <Toast ref={el => (toast.current = el)} />
    </div>
  );
};

export default ForgotPassword;
