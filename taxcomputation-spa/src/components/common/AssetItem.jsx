import React from "react";
import { deleteAssetClass } from "../../apis/Utilities";

const AssetItem = ({
  assetData,
  onAssetList,
  setShowAssetList,
  setShowCreateAsset,
  onSelectedAsset
}) => {
  const [isDeleting, setIsDeleting] = React.useState(false);

  return (
    <div className="p-d-flex p-jc-between p-ai-center">
      <p style={{ marginTop: 10, marginBottom: 10 }}>{assetData.assetName}</p>
      <div>
        <i
          className="pi pi-pencil edit"
          onClick={() => {
            onSelectedAsset(assetData);
            setShowAssetList(false);
            setShowCreateAsset(true);
          }}></i>
        <i
          className={isDeleting ? "pi pi-spin pi-spinner" : "pi pi-trash delete"}
          style={{ marginLeft: 20, marginRight: 10 }}
          onClick={async () => {
            try {
              setIsDeleting(true);
              const response = await deleteAssetClass(assetData.id);
              if (response.status === 200) onAssetList(null);
            } catch (error) {
              console.log("Failed to delete asset");
            } finally {
              setIsDeleting(false);
            }
          }}></i>
      </div>
    </div>
  );
};

export default AssetItem;
