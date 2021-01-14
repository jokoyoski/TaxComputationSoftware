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

export const fixedAssetViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(`/api/FixedAsset/${companyId}/${year}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const fixedAssetUnmapping = async ({ id }) => {
  try {
    return await axios.put(`/api/FixedAsset/fixed-asset/${id}`);
  } catch (error) {
    throw error;
  }
};

export const fixedAssetDelete = async id => {
  try {
    const { data } = await axios.delete(`/api/FixedAsset/delete-fixed-asset/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};
