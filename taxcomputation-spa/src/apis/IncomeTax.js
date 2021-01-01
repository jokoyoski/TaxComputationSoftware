import axios from "axios";

export const incomeTaxMapping = async ({
  lossBroughtFoward,
  unrelievedCapitalAllowanceBroughtFoward,
  trialBalanceId
}) => {
  try {
    return await axios.post("/api/IncomeTax/add-income-tax", {
      lossBroughtFoward,
      unrelievedCapitalAllowanceBroughtFoward,
      trialBalanceId
    });
  } catch (error) {
    throw error;
  }
};

export const incomeTaxViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(`/api/incomeTax/${companyId}/${year}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const incomeTaxDelete = async id => {
  try {
    const { data } = await axios.delete(`/api/InvestmentAllowance/investment-allowance/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};
