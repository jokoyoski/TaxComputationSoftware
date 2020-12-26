import axios from "axios";

export const incomeTaxMapping = async ({
  typeId,
  yearId,
  lossBroughtFoward,
  unrelievedCapitalAllowanceBroughtFoward,
  incomeList,
  companyId
}) => {
  try {
    return await axios.post("/api/IncomeTax/add-income-tax", {
      typeId,
      yearId,
      lossBroughtFoward,
      unrelievedCapitalAllowanceBroughtFoward,
      incomeList,
      companyId
    });
  } catch (error) {
    throw error;
  }
};

export const incomeTaxViewData = async ({ companyId, year, isItLevyView }) => {
  try {
    const { data } = await axios.get(`/api/incomeTax/${companyId}/${year}/${isItLevyView}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const incomeTaxDelete = async id => {
  try {
    const { data } = await axios.delete(`/api/IncomeTax/remove-allowable/disallowable/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};
