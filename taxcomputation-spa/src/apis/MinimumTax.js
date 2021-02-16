import axios from "axios";

export const minimumTaxMapping = async ({
  companyId,
  financialYearId,
  grossProft,
  netAsset,
  shareCapital
}) => {
  try {
    return await axios.post("/api/MinimumTax", {
      companyId,
      financialYearId,
      grossProft,
      netAsset,
      shareCapital
    });
  } catch (error) {
    throw error;
  }
};

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

export const minimumTaxOldViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(
      `/api/MinimumTax?companyId=${companyId}&financialYearId=${year}`
    );
    return data;
  } catch (error) {
    throw error;
  }
};
