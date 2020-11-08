import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import { Toast } from "primereact/toast";
import { useForm, Controller } from "react-hook-form";
import { login } from "../apis/Authentication";
import constants from "../constants";
import { useAuth } from "../store/AuthStore";
import { Link, Redirect, useRouter, useRouterActions } from "react-resource-router";
import PasswordInput from "../components/common/PasswordInput";
import utils from "../utils";

const Login = () => {
  const [routerState] = useRouter();
  const { errors, handleSubmit, control } = useForm();
  const [{ isAuthenticated }, { onLoginSuccess }] = useAuth();
  const { push } = useRouterActions();
  const [loading, setLoading] = React.useState(false);
  const toast = React.useRef();

  React.useEffect(() => {
    if (routerState.location.state)
      toast.current.show(
        utils.toastCallback({ severity: "success", detail: routerState.location.state })
      );
  }, [routerState]);

  const onSubmit = async data => {
    if (loading) return;

    setLoading(true);
    const { email, password } = data;
    try {
      const {
        token,
        user: { id, firstName, lastName }
      } = await login({ email, password });
      // store user details in global state
      onLoginSuccess({ id, token, email, firstName, lastName });
      push(constants.routes.dashboard);
    } catch (error) {
      setLoading(false);
      if (error.response) {
        const {
          data: { errors }
        } = error.response;
        // display all errors as toast notification
        errors.map(err =>
          toast.current.show(
            utils.toastCallback({ severity: "error", summary: "Login Error", detail: err })
          )
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
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="password"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <PasswordInput
                  placeholder="Password"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.password && (
              <span style={{ fontSize: 12, color: "red" }}>Password is required</span>
            )}
          </div>
          <Button
            type="submit"
            label={!loading ? "Login" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: "100%" }}
          />
        </form>
        <Link href={constants.routes.forgot_password} className="auth-link">
          <p style={{ marginBottom: 0, marginTop: 20, fontSize: 14 }}>Forgot Password</p>
        </Link>
      </Card>
      <Toast ref={el => (toast.current = el)} />
    </div>
  );
};

export default Login;
