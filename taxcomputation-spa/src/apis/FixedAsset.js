import axios from "axios";

export const fixedAssetMapping = async ({
  companyId,
  yearId,
  mappedCode,
  assetId,
  triBalanceId,
  isCost,
  openingCost,
  transferCost,
  transferDepreciation,
  isTransferCostRemoved,
  isTransferDepreciationRemoved,
  costAddition,
  costDisposal,
  openingDepreciation,
  depreciationAddition,
  depreciationDisposal
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
      transferCost,
      transferDepreciation,
      isTransferCostRemoved,
      isTransferDepreciationRemoved,
      costAddition,
      costDisposal,
      openingDepreciation,
      depreciationAddition,
      depreciationDisposal
    });
  } catch (error) {
    throw error;
  }
};
