import axios from "axios";

export const rollover = async id => {
  try {
    return await axios.post(`/api/RollOver?companyId=${id}`);
  } catch (error) {
    throw error;
  }
};

export const rollback = async id => {
  try {
    return await axios.post(`/api/RollOver/rollback?companyId=${id}`);
  } catch (error) {
    throw error;
  }
};
