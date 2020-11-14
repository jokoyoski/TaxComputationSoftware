import axios from "axios";

export const getModuleItems = async ({ moduleCode }) => {
  try {
    const { data } = await axios.get(`/api/Utilities/module-items/${moduleCode}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const createAssetClass = async ({ assetName, initial, annual }) => {
  try {
    return await axios.post("/api/Utilities/asset-class", { assetName, initial, annual });
  } catch (error) {
    throw error;
  }
};
