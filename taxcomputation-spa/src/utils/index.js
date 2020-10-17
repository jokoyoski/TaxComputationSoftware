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
  },
  defaultMode: title => (constants.nonMappedModules.includes(title) ? "view" : "mapping"),
  saveState: state => {
    try {
      const serializedState = JSON.stringify(state);
      sessionStorage.setItem("state", serializedState);
    } catch (err) {
      console.log(err);
    }
  },
  loadState: () => {
    try {
      const serializedState = sessionStorage.getItem("state");
      if (serializedState === null) {
        return undefined;
      }
      sessionStorage.removeItem("state");
      return JSON.parse(serializedState);
    } catch (err) {
      return undefined;
    }
  }
};
