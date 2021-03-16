import axios from "axios";

export const addEditCompany = async ({
  companyId,
  companyName,
  companyDescription,
  cacNumber,
  tinNumber,
  closingYear,
  openingYear,
  monthOfOperation,
  unRelievedCf,
  lossCf,
  deferredTaxBroughtFoward,
  minimumTaxTypeId
}) => {
  try {
    return await axios.post("/api/Companies/add-company", {
      companyId,
      companyName,
      companyDescription,
      cacNumber,
      tinNumber,
      closingYear,
      openingYear,
      monthOfOperation,
      unRelievedCf,
      lossCf,
      deferredTaxBroughtFoward,
      minimumTaxTypeId
    });
  } catch (error) {
    throw error;
  }
};

export const getCompanies = async (pageNumber = 1, pageSize = 1000) => {
  try {
    const { data } = await axios.get(
      `/api/Companies/get-companies${
        pageNumber && pageSize ? `?PageNumber=${pageNumber}&PageSIze=${pageSize}` : ""
      }`
    );
    return data;
  } catch (error) {
    throw error;
  }
};

export const getCompany = async companyId => {
  try {
    const { data } = await axios.get(`/api/Companies/get-company/${companyId}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const getCompanyViewHeaderData = async (companyId, yearId) => {
  try {
    const { data } = await axios.get(
      `/api/Companies?companyId=${companyId}&financialYearId=${yearId}`
    );
    return data;
  } catch (error) {
    throw error;
  }
};

export const deleteCompany = async companyId => {
  try {
    return await axios.delete(`/api/Companies?companyId=${companyId}`);
  } catch (error) {
    throw error;
  }
};
