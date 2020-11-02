import axios from "axios";

export const addUser = async ({
  email,
  password,
  confirmPassword,
  phoneNumber,
  firstName,
  lastName
}) => {
  try {
    return await axios.post("/api/Users/add-user", {
      email,
      password,
      confirmPassword,
      phoneNumber,
      firstName,
      lastName
    });
  } catch (error) {
    throw error;
  }
};
