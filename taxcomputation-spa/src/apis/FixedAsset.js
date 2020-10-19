import axios from "axios";

export const fixedAssetMapping = async ({
  companyId,
  yearId,
  mappedCode,
  assetId,
  triBalanceId,
  isCost,
  openingCost,
  costAddition,
  costDisposal,
  costClosing,
  openingDepreciation,
  depreciationAddition,
  depreciationDisposal,
  depreciationClosing
}) => {
  try {
    return await axios.post("/api/FixedAsset", {
      companyId,
      yearId,
      mappedCode,
      assetId,
      triBalanceId,
      isCost,
      openingCost,
      costAddition,
      costDisposal,
      costClosing,
      openingDepreciation,
      depreciationAddition,
      depreciationDisposal,
      depreciationClosing
    });
  } catch (error) {
    throw error;
  }
};
