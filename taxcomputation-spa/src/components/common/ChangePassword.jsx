import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { Toast } from "primereact/toast";
import { useForm, Controller } from "react-hook-form";
import { useRouter } from "react-resource-router";
import PasswordController from "../controllers/PasswordController";
import { changePassword } from "../../apis/Authentication";
import constants from "../../constants";
import { useAuth } from "../../store/AuthStore";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";

const ChangePassword = ({ setShowChangePassword }) => {
  const [routerState] = useRouter();
  const { errors, handleSubmit, control } = useForm();
  const [, { onLogout }] = useAuth();
  const [, { resetCompany }] = useCompany();
  const [loading, setLoading] = React.useState(false);
  const [toast, setToast] = React.useState(null);

  React.useEffect(() => {
    if (routerState.location.state)
      toast.show(utils.toastCallback({ severity: "success", detail: routerState.location.state }));
  }, [routerState, toast]);

  const onSubmit = async data => {
    if (loading) return;

    const { currentPassword, newPassword } = data;
    // display error notification if current password and new password are the same
    if (currentPassword === newPassword) {
      toast.show(
        utils.toastCallback({
          severity: "error",
          detail: "Current Password and New Password cannot be the same"
        })
      );
      return;
    }

    setLoading(true);
    try {
      const { message } = await changePassword({ currentPassword, newPassword });
      routerState.location.state = message;
      onLogout(resetCompany);
    } catch (error) {
      setLoading(false);
      if (error.response) {
        const { data } = error.response;
        // display error as toast notification
        toast.show(
          utils.toastCallback({
            severity: "error",
            summary: "Error",
            detail: data.message || data.errors.NewPassword[0]
          })
        );
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

  return (
    <div className="p-d-flex p-jc-center p-ai-center overlay">
      <Card style={{ width: 320 }}>
        <form className="p-d-flex p-flex-column" onSubmit={handleSubmit(onSubmit)}>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="currentPassword"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <PasswordController
                  placeholder="Current Password"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.currentPassword && (
              <span style={{ fontSize: 12, color: "red" }}>Current Password is required</span>
            )}
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
            label={!loading ? "Change Password" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: "100%" }}
          />
        </form>
        {!loading && (
          <p className="back-to-app-link" onClick={() => setShowChangePassword(state => !state)}>
            Back to App
          </p>
        )}
      </Card>
      <Toast ref={el => setToast(el)} />
    </div>
  );
};

export default ChangePassword;
