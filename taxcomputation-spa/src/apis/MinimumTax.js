import axios from "axios";

export const minimumTaxViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(`/api/MinimumTax/${companyId}/${year}`);
    return data;
  } catch (error) {
    throw error;
  }
};
