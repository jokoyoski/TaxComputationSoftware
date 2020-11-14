import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { Toast } from "primereact/toast";
import { useForm, Controller } from "react-hook-form";
import constants from "../../constants";
import { InputText } from "primereact/inputtext";
import utils from "../../utils";
import { createAssetClass } from "../../apis/Utilities";

const CreateAsset = ({ setShowCreateAsset }) => {
  const { errors, handleSubmit, control } = useForm();
  const [loading, setLoading] = React.useState(false);
  const toast = React.useRef();

  const onSubmit = async data => {
    if (loading) return;

    const { assetName, initial, annual } = data;

    setLoading(true);
    try {
      const response = await createAssetClass({
        assetName,
        initial: initial ? initial : 0,
        annual: annual ? annual : 0
      });
      if (response.status === 200) {
        toast.current.show(
          utils.toastCallback({
            severity: "success",
            detail: "Asset created successfully"
          })
        );
        setTimeout(() => setShowCreateAsset(false), 2000);
      }
    } catch (error) {
      setLoading(false);
      if (error.response) {
        const { data } = error.response;
        data.errors.error.forEach(err => {
          toast.current.show(
            utils.toastCallback({
              severity: "error",
              detail: err
            })
          );
        });
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

  return (
    <div className="p-d-flex p-jc-center p-ai-center overlay">
      <Card style={{ width: 320 }}>
        <form className="p-d-flex p-flex-column" onSubmit={handleSubmit(onSubmit)}>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="assetName"
              control={control}
              rules={{ required: true }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
                  placeholder="Asset Name"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.assetName && (
              <span style={{ fontSize: 12, color: "red" }}>Asset Name is required</span>
            )}
          </div>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="initial"
              control={control}
              rules={{ pattern: /^\d*(\.\d+)?$/ }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
                  placeholder="Initial"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.initial && (
              <span style={{ fontSize: 12, color: "red" }}>Initial must contain only numbers</span>
            )}
          </div>
          <div style={{ marginBottom: 15 }}>
            <Controller
              name="annual"
              control={control}
              rules={{ pattern: /^\d*(\.\d+)?$/ }}
              defaultValue=""
              render={props => (
                <InputText
                  style={{ marginBottom: 5, width: "100%", paddingRight: 33 }}
                  placeholder="Annual"
                  value={props.value}
                  onChange={e => props.onChange(e.target.value)}
                />
              )}
            />
            {errors.annual && (
              <span style={{ fontSize: 12, color: "red" }}>Annual must contain only numbers</span>
            )}
          </div>
          <Button
            type="submit"
            label={!loading ? "Create Asset" : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: "100%" }}
          />
        </form>
        {!loading && (
          <p className="back-to-app-link" onClick={() => setShowCreateAsset(state => !state)}>
            Back to app
          </p>
        )}
      </Card>
      <Toast ref={el => (toast.current = el)} />
    </div>
  );
};

export default CreateAsset;
