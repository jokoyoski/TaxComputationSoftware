import axios from "axios";

export const getModuleItems = async ({ moduleCode }) => {
  try {
    const { data } = await axios.get(`/api/Utilities/module-items/${moduleCode}`);
    return data;
  } catch (error) {
    throw error;
  }
};
