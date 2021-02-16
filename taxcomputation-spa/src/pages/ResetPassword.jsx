import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Toast } from "primereact/toast";
import { useForm, Controller } from "react-hook-form";
import { resetPassword } from "../apis/Authentication";
import constants from "../constants";
import { useAuth } from "../store/AuthStore";
import { Link, Redirect, useRouter, useRouterActions } from "react-resource-router";
import PasswordController from "../components/controllers/PasswordController";
import utils from "../utils";

const ResetPassword = () => {
  const [routerState] = useRouter();
  const { errors, handleSubmit, control } = useForm();
  const [{ isAuthenticated }] = useAuth();
  const { push } = useRouterActions();
  const [loading, setLoading] = React.useState(false);
  const [toast, setToast] = React.useState(null);

  React.useEffect(() => {
    if (routerState.location.state)
      toast.show(utils.toastCallback({ severity: "success", detail: routerState.location.state }));
  }, [routerState, toast]);

  const onSubmit = async data => {
    if (loading) return;

    setLoading(true);
    const { token, newPassword } = data;
    try {
      const { message } = await resetPassword({ token, newPassword });
      push({ pathname: constants.routes.login, state: message });
    } catch (error) {
      setLoading(false);
      if (error.response) {
        const {
          data: { message }
        } = error.response;
        // display error as toast notification
        toast.show(utils.toastCallback({ severity: "error", summary: "Error", detail: message }));
      } else {
        // network errors
        toast.show(
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
              name="token"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%" }}
                  placeholder="Token"
                  maxLength={4}
                  keyfilter="pint"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.token && <span style={{ fontSize: 12, color: "red" }}>Token is required</span>}
          </div>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="newPassword"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <PasswordController
                  placeholder="New Password"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.newPassword && (
              <span style={{ fontSize: 12, color: "red" }}>New Password is required</span>
            )}
          </div>
          <Button
            type="submit"
            label={!loading ? "Reset Password" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: "100%" }}
          />
        </form>
        <Link href={constants.routes.login} className="auth-link">
          <p style={{ marginBottom: 0, marginTop: 20, fontSize: 14 }}>Back to login</p>
        </Link>
      </Card>
      <Toast ref={el => setToast(el)} />
    </div>
  );
};

export default ResetPassword;
