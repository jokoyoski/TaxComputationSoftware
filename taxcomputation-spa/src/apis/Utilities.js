import axios from "axios";

export const getModuleItems = async ({ moduleCode }) => {
  try {
    const { data } = await axios.get(`/api/Utilities/module-items/${moduleCode}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const getAssetClass = async () => {
  try {
    return await axios.get(`/api/Utilities/asset-class/`);
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

export const updateAssetClass = async ({ id, assetName, initial, annual }) => {
  try {
    return await axios.put(`/api/Utilities/asset-class/${id}`, {
      assetName,
      initial,
      annual
    });
  } catch (error) {
    throw error;
  }
};

export const deleteAssetClass = async id => {
  try {
    return await axios.delete(`/api/Utilities/asset-class/${id}`);
  } catch (error) {
    throw error;
  }
};

export const getCompanyFinancialYear = async companyId => {
  try {
    const { data } = await axios.get(
      `/api/Utilities/company-financial-year?companyId=${companyId}`
    );
    return data;
  } catch (error) {
    throw error;
  }
};
