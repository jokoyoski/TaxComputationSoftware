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
  defaultMode: title =>
    constants.nonMappedModules.includes(title)
      ? "view"
      : [constants.modules.balancingAdjustment, constants.modules.capitalAllowance].includes(title)
      ? "adding"
      : "mapping",
  saveState: (state, stateName) => {
    try {
      const serializedState = JSON.stringify(state);
      sessionStorage.setItem(stateName, serializedState);
    } catch (err) {
      console.log(err);
    }
  },
  loadState: stateName => {
    try {
      const serializedState = sessionStorage.getItem(stateName);
      if (serializedState === null) {
        return undefined;
      }
      sessionStorage.removeItem(stateName);
      return JSON.parse(serializedState);
    } catch (err) {
      return undefined;
    }
  },
  currencyFormatter: value => {
    const formatter = new Intl.NumberFormat("en-NG", {
      style: "currency",
      currency: "NGN"
    });

    return formatter.format(value);
  },
  toastCallback: ({ severity, summary, detail }) => ({
    severity,
    summary,
    detail,
    life: constants.toastLifeTime,
    closable: false
  })
};
