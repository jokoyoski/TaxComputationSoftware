import axios from "axios";

export const deferredTaxMapping = async ({
  fairValueGainId,
  trialBalanceList,
  companyId,
  yearId
}) => {
  try {
    return await axios.post("/api/DeferredTax", {
      fairValueGainId,
      trialBalanceList,
      companyId,
      yearId
    });
  } catch (error) {
    throw error;
  }
};

export const deferredTaxViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(`/api/DeferredTax?companyId=${companyId}&year=${year}`);
    return data;
  } catch (error) {
    throw error;
  }
};

/** TODO: Update endpoint url when available */
export const deferredTaxDelete = async id => {
  try {
    const { data } = await axios.delete(`/api/InvestmentAllowance/investment-allowance/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};
