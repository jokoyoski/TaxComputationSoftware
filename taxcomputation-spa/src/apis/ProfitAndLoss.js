import axios from "axios";

export const profitAndLossMapping = async ({
  profitAndLossId,
  trialBalanceList,
  companyId,
  yearId,
  mappedCode
}) => {
  try {
    return await axios.post("/api/ProfitAndLoss", {
      profitAndLossId,
      trialBalanceList,
      companyId,
      yearId,
      mappedCode
    });
  } catch (error) {
    throw error;
  }
};
