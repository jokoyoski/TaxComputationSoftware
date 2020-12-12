import axios from "axios";

export const investmentAllowanceMapping = async ({ companyId, assetId, yearId }) => {
  try {
    return await axios.post("/api/InvestmentAllowance/investment-allowance", {
      companyId,
      assetId,
      yearId
    });
  } catch (error) {
    throw error;
  }
};

export const investmentAllowanceViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(`/api/InvestmentAllowance/${companyId}/${year}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const investmentAllowanceDelete = async ({ id }) => {
  try {
    const { data } = await axios.delete(`/api/InvestmentAllowance/investment-allowance/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};
