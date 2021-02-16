import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { Toast } from "primereact/toast";
import { useForm, Controller } from "react-hook-form";
import constants from "../../constants";
import utils from "../../utils";
import { createAssetClass, updateAssetClass } from "../../apis/Utilities";
import { useResources } from "../../store/ResourcesStore";
import InputController from "../controllers/InputController";

const CreateAsset = ({ setShowCreateAsset, setShowAssetList }) => {
  const { errors, handleSubmit, control } = useForm();
  const [{ selectedAsset }, { onAssetList }] = useResources();
  const [loading, setLoading] = React.useState(false);
  const [toast, setToast] = React.useState(null);

  const onSubmit = async data => {
    if (loading) return;

    const { assetName, initial, annual } = data;

    setLoading(true);
    try {
      const response = selectedAsset
        ? await updateAssetClass({ id: selectedAsset.id, assetName, initial, annual })
        : await createAssetClass({
            assetName,
            initial: initial ? initial : 0,
            annual: annual ? annual : 0
          });
      if (response.status === 200) {
        toast.show(
          utils.toastCallback({
            severity: "success",
            detail: selectedAsset ? "Asset updated successfully" : "Asset created successfully"
          })
        );
        setTimeout(() => {
          onAssetList(null);
          setShowCreateAsset(false);
          setShowAssetList(true);
        }, 2000);
      }
    } catch (error) {
      setLoading(false);
      if (error.response) {
        const { data } = error.response;
        data.errors.error.forEach(err => {
          toast.show(
            utils.toastCallback({
              severity: "error",
              detail: err
            })
          );
        });
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
            <InputController
              Controller={Controller}
              control={control}
              errors={errors}
              controllerName="assetName"
              label="Asset Name"
              defaultValue={selectedAsset ? selectedAsset.assetName : ""}
              required
              width="100%"
              errorMessage="Asset Name is required"
            />
          </div>
          <div style={{ marginBottom: 15 }}>
            <InputController
              Controller={Controller}
              control={control}
              errors={errors}
              controllerName="initial"
              label="Initial"
              defaultValue={selectedAsset ? selectedAsset.initial : ""}
              otherRules={{ pattern: /^\d*(\.\d+)?$/ }}
              width="100%"
              errorMessage="Initial must contain only numbers"
            />
          </div>
          <div style={{ marginBottom: 15 }}>
            <InputController
              Controller={Controller}
              control={control}
              errors={errors}
              controllerName="annual"
              label="Annual"
              defaultValue={selectedAsset ? selectedAsset.annual : ""}
              otherRules={{ pattern: /^\d*(\.\d+)?$/ }}
              width="100%"
              errorMessage="Annual must contain only numbers"
            />
          </div>
          <Button
            type="submit"
            label={!loading ? (!selectedAsset ? "Create Asset" : "Update Asset") : null}
            icon={loading ? "pi pi-spin pi-spinner" : null}
            style={{ width: "100%" }}
          />
        </form>
        {!loading && (
          <p
            className="back-to-app-link"
            onClick={() => {
              setShowCreateAsset(false);
              setShowAssetList(true);
            }}>
            Back to Asset List
          </p>
        )}
      </Card>
      <Toast ref={el => setToast(el)} />
    </div>
  );
};

export default CreateAsset;
