import axios from "axios";

export const uploadTrialBalance = async ({ file, companyId, year }) => {
  try {
    var formData = new FormData();
    formData.append("File", file.item(0));
    formData.append("CompanyId", companyId);
    formData.append("YearId", year);
    return await axios.post("/api/TrialBalance", formData, {
      headers: {
        "Content-Type": "multipart/form-data"
      }
    });
  } catch (error) {
    throw error;
  }
};

export const getTrialBalance = async ({ companyId, year }) => {
  try {
    const { data } = await axios.get(`/api/TrialBalance?companyId=${companyId}&yearId=${year}`);
    return data;
  } catch (error) {
    throw error;
  }
};
