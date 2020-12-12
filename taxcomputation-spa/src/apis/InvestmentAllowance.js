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
