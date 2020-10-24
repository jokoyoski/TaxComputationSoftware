import axios from "axios";

export const getAssetClass = async () => {
  try {
    const { data } = await axios.get("/api/Utilities/asset-class");
    return data;
  } catch (error) {
    throw error;
  }
};
