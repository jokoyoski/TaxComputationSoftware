import constants from "../constants";

export default {
  currentYear: () => new Date().getFullYear(),
  getYears: () => {
    let currentYear = new Date().getFullYear();
    let years = [];
    for (var i = currentYear; i >= constants.startYear; i--) {
      years.push(i);
    }
    return years;
  }
};
