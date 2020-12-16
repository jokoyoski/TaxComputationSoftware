import axios from "axios";

export const capitalAllowanceAdding = async ({
  companyId,
  taxYear,
  assetId,
  openingResidue,
  addition,
  disposal,
  initial,
  annual,
  total,
  closingResidue,
  yearsToGo
}) => {
  try {
    return await axios.post("/api/CapitalAllowance", {
      companyId,
      taxYear,
      assetId,
      openingResidue,
      addition,
      disposal,
      initial,
      annual,
      total,
      closingResidue,
      yearsToGo
    });
  } catch (error) {
    throw error;
  }
};

export const capitalAllowanceViewData = async ({ companyId, assetId }) => {
  try {
    const { data } = await axios.get(`/api/CapitalAllowance/${companyId}/${assetId}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const capitalAllowanceSummaryData = async ({ companyId }) => {
  try {
    const { data } = await axios.get(
      `/api/CapitalAllowanceSummary/companyId?companyId=${companyId}`
    );
    return data;
  } catch (error) {
    throw error;
  }
};

export const capitalAllowanceDelete = async ({ id }) => {
  try {
    const { data } = await axios.delete(`/api/CapitalAllowance/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};
