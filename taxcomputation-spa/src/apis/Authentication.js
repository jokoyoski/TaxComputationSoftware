import axios from "axios";

export const login = async ({ email, password }) => {
  try {
    const { data } = await axios.post("/api/Authentication/login", { email, password });
    return data;
  } catch (error) {
    throw error;
  }
};
