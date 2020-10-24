import axios from "axios";

export const login = async ({ email, password }) => {
  try {
    const { data } = await axios.post("/api/Authentication/login", { email, password });
    return data;
  } catch (error) {
    throw error;
  }
};

export const forgotPassword = async ({ email }) => {
  try {
    const { data } = await axios.post(`/api/Authentication/forgot-password/${email}`);
    return data;
  } catch (error) {
    throw error;
  }
};

export const resetPassword = async ({ token, newPassword }) => {
  try {
    const { data } = await axios.post("/api/Authentication/reset-password", {
      token,
      newPassword,
      confirmPassword: newPassword
    });
    return data;
  } catch (error) {
    throw error;
  }
};
