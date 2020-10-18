import axios from "axios";

export const addCompany = async ({ companyName, companyDescription, cacNumber, tinNumber }) =>
  await axios.post("/api/Companies/add-company", {
    companyName,
    companyDescription,
    cacNumber,
    tinNumber
  });
