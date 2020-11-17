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