import axios from "axios";

export const addCompany = async ({ companyName, companyDescription, cacNumber, tinNumber }) => {
  try {
    return await axios.post("/api/Companies/add-company", {
      companyName,
      companyDescription,
      cacNumber,
      tinNumber
    });
  } catch (error) {
    throw error;
  }
};

export const getCompanies = async (pageNumber = 1, pageSize = 100) => {
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
