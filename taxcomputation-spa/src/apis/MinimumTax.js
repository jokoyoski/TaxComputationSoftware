import axios from "axios";

export const minimumTaxViewData = async ({ companyId, year, percentageTurnOver }) => {
  try {
    const { data } = await axios.get(
      `/api/MinimumTax/${companyId}/${year}?percenttageTurnOver=${percentageTurnOver}`
    );
    return data;
  } catch (error) {
    throw error;
  }
};
