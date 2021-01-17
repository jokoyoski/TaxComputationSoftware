import React from "react";
import { Dialog } from "primereact/dialog";
import { Button } from "primereact/button";
import { getAssetClass } from "../../apis/Utilities";
import AssetItem from "./AssetItem";
import Loader from "./Loader";
import { useResources } from "../../store/ResourcesStore";

const AssetList = ({ showAssetList, setShowAssetList, setShowCreateAsset }) => {
  const [loading, setLoading] = React.useState(false);
  const [error, setError] = React.useState(null);
  const [{ assetList }, { onAssetList, onSelectedAsset }] = useResources();

  React.useEffect(() => {
    const fetchAssets = async () => {
      if (!assetList) {
        try {
          setLoading(true);
          setError(null);
          const response = await getAssetClass();
          if (response.status === 200) onAssetList(response.data);
        } catch (error) {
          setError("Failed to get all assets");
        } finally {
          setLoading(false);
        }
      }
    };
    fetchAssets();
  }, [assetList, onAssetList]);

  return (
    <Dialog
      header="Asset List"
      footer={
        <div>
          <Button
            label="Add Asset"
            onClick={() => {
              onSelectedAsset(null);
              setShowCreateAsset(true);
              setShowAssetList(false);
            }}
          />
        </div>
      }
      visible={showAssetList}
      style={{ width: 500 }}
      blockScroll
      focusOnShow={false}
      closeOnEscape
      closable
      onHide={() => setShowAssetList(false)}>
      <div className="p-d-flex p-flex-column" style={{ height: 300 }}>
        {loading && (
          <div
            className="p-d-flex p-jc-center p-ai-center"
            style={{ height: "100%", width: "100%" }}>
            <Loader />
          </div>
        )}
        {error && (
          <div
            className="p-d-flex p-flex-column p-jc-center p-ai-center"
            style={{ height: "100%", width: "100%" }}>
            <p style={{ marginTop: 10, marginBottom: 10, marginRight: 10 }}>{error}</p>
            <Button className="p-button-outlined" label="Retry" onClick={() => onAssetList(null)} />
          </div>
        )}
        {assetList &&
          assetList.map(item => (
            <AssetItem
              key={item.id}
              assetData={item}
              onAssetList={onAssetList}
              setShowAssetList={setShowAssetList}
              setShowCreateAsset={setShowCreateAsset}
              onSelectedAsset={onSelectedAsset}
            />
          ))}
      </div>
    </Dialog>
  );
};

export default AssetList;
