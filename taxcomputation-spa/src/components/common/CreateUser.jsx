import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { Toast } from "primereact/toast";
import { useForm, Controller } from "react-hook-form";
import PasswordController from "../controllers/PasswordController";
import constants from "../../constants";
import { InputText } from "primereact/inputtext";
import { addUser } from "../../apis/Users";
import utils from "../../utils";

const CreateUser = ({ setShowCreateUser }) => {
  const { errors, handleSubmit, control } = useForm();
  const [loading, setLoading] = React.useState(false);
  const [toast, setToast] = React.useState(null);

  const onSubmit = async data => {
    if (loading) return;

    const { email, password, firstName, lastName, phoneNumber } = data;
    const confirmPassword = password;

    setLoading(true);
    try {
      const response = await addUser({
        email,
        password,
        confirmPassword,
        firstName,
        lastName,
        phoneNumber
      });
      if (response.status === 201) {
        toast.show(
          utils.toastCallback({
            severity: "success",
            detail: "User created successfully"
          })
        );
        setTimeout(() => setShowCreateUser(false), 2000);
      }
    } catch (error) {
      setLoading(false);
      if (error.response) {
        const { data } = error.response;
        // display error as toast notification
        toast.show(
          utils.toastCallback({
            severity: "error",
            summary: data[0].code,
            detail: data[0].description
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
              name="email"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
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
                <PasswordController
                  placeholder="Password"
                  autoComplete="new-password"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.password && (
              <span style={{ fontSize: 12, color: "red" }}>Password is required</span>
            )}
          </div>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="firstName"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
                  placeholder="First Name"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.firstName && (
              <span style={{ fontSize: 12, color: "red" }}>First Name is required</span>
            )}
          </div>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="lastName"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
                  placeholder="Last Name"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.lastName && (
              <span style={{ fontSize: 12, color: "red" }}>Last Name is required</span>
            )}
          </div>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="phoneNumber"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
                  placeholder="Phone Number"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.phoneNumber && (
              <span style={{ fontSize: 12, color: "red" }}>Phone Number is required</span>
            )}
          </div>
          <Button
            type="submit"
            label={!loading ? "Create User" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: "100%" }}
          />
        </form>
        {!loading && (
          <p className="back-to-app-link" onClick={() => setShowCreateUser(state => !state)}>
            Back to App
          </p>
        )}
      </Card>
      <Toast ref={el => setToast(el)} />
    </div>
  );
};

export default CreateUser;
