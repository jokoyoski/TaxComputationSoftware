import constants from "../constants";

/** get current year */
const currentYear = () => new Date().getFullYear();

/** get years from start year to current year */
const getYears = () => {
  let currentYear = new Date().getFullYear();
  let years = [];
  for (var i = currentYear; i >= constants.startYear; i--) {
    years.push(i);
  }
  return years;
};

/** default page mode */
const defaultMode = title =>
  constants.nonMappedModules.includes(title)
    ? "view"
    : [constants.modules.balancingAdjustment, constants.modules.capitalAllowance].includes(title)
    ? "adding"
    : "mapping";

/** save store state */
const saveState = (state, stateName) => {
  try {
    const serializedState = JSON.stringify(state);
    sessionStorage.setItem(stateName, serializedState);
  } catch (err) {
    console.log(err);
  }
};

/** load store state */
const loadState = stateName => {
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
};

/** convert number to currency */
const currencyFormatter = value => {
  const formatter = new Intl.NumberFormat("en-NG", {
    style: "currency",
    currency: "NGN"
  });

  return formatter.format(value);
};

/** toast notification callback function */
const toastCallback = ({ severity, summary, detail }) => ({
  severity,
  summary,
  detail,
  life: constants.toastLifeTime,
  closable: false
});

/** set trial balance data */
const onTbData = (resources, setTbData) => {
  if (resources.trialBalance) {
    setTbData(
      resources.trialBalance
        ? resources.trialBalance
            .filter(
              d =>
                !(d.accountId === "" && d.item === "" && d.debit === 0 && d.credit === 0) &&
                !d.item.toLowerCase().includes("total")
            )
            .map(d => ({
              ...d,
              debitAmt: currencyFormatter(d.debit),
              creditAmt: currencyFormatter(d.credit)
            }))
        : []
    );
  }
};

/** api error handling */
const apiErrorHandling = (error, toast) => {
  if (error.response.data.errors) {
    toast.show(
      toastCallback({
        severity: "error",
        detail: error.response.data.errors[0]
      })
    );
  } else {
    toast.show(
      toastCallback({
        severity: "error",
        summary: "Network Error",
        detail: constants.networkErrorMessage
      })
    );
  }
};

/** mapping successful callback */
const onMappingSuccess = (
  toast,
  detail,
  onTrialBalance,
  trialBalanceRefresh,
  setSelectedAccounts
) => {
  toast.show(
    toastCallback({
      severity: "success",
      detail
    })
  );
  onTrialBalance(null);
  trialBalanceRefresh();
  setSelectedAccounts([]);
};

export default {
  currentYear,
  getYears,
  defaultMode,
  saveState,
  loadState,
  currencyFormatter,
  toastCallback,
  onTbData,
  apiErrorHandling,
  onMappingSuccess
};
