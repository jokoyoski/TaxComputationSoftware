import axios from "axios";

export const itLevyViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(`/api/ITLevy/${companyId}/${year}`);
    return data;
  } catch (error) {
    throw error;
  }
};
