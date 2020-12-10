import axios from "axios";

export const balancingAdjustmentAdding = async ({
  year,
  assetId,
  cost,
  salesProceed,
  yearBought,
  companyId
}) => {
  try {
    var formData = new FormData();
    formData.append("Year", year);
    formData.append("AssetId", assetId);
    formData.append("Cost", cost);
    formData.append("SalesProceed", salesProceed);
    formData.append("YearBought", yearBought);
    formData.append("CompanyId", companyId);
    return await axios.post("/api/BalancingAdjustment", formData, {
      headers: {
        "Content-Type": "multipart/form-data"
      }
    });
  } catch (error) {
    throw error;
  }
};

export const balancingAdjustmentViewData = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(
      `/api/BalancingAdjustment?companyId=${companyId}&year=${year}`
    );
    return data;
  } catch (error) {
    throw error;
  }
};

export const balancingAdjustmentDelete = async ({ id }) => {
  try {
    const { data } = await axios.delete(`/api/BalancingAdjustment/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};
