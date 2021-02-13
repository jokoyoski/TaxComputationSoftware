import axios from "axios";

export const profitAndLossMapping = async ({
  profitAndLossId,
  trialBalanceList,
  companyId,
  yearId,
  mappedCode,
  isAllowable,
  isDisAllowable
}) => {
  try {
    return await axios.post("/api/ProfitAndLoss", {
      profitAndLossId,
      trialBalanceList,
      companyId,
      yearId,
      mappedCode,
      isAllowable,
      isDisAllowable
    });
  } catch (error) {
    throw error;
  }
};

export const profitAndLossViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(`/api/ProfitAndLoss/${companyId}/${year}`);
    return data;
  } catch (error) {
    throw error;
  }
};
