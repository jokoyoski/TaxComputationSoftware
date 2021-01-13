import { getCompanyFinancialYear } from "../apis/Utilities";
import constants from "../constants";

/** get current year */
const currentYear = () => Number(sessionStorage.getItem("year"));

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
  let errorString = "";

  if (error?.response?.data?.errors) {
    errorString = error.response.data.errors[0];
    if (toast) {
      toast.show(
        toastCallback({
          severity: "error",
          detail: errorString
        })
      );
    }
  } else {
    errorString = constants.networkErrorMessage;
    if (toast) {
      toast.show(
        toastCallback({
          severity: "error",
          summary: "Network Error",
          detail: errorString
        })
      );
    }
  }

  return errorString;
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
  setTimeout(() => {
    onTrialBalance(null);
    trialBalanceRefresh();
    setSelectedAccounts([]);
  }, 2000);
};

/** fetch company financial year */
const fetchCompanyFinancialYear = (company, onFinancialYear, toast) => {
  const fetcher = async () => {
    if (!company.companyId) return;

    try {
      const data = await getCompanyFinancialYear(company.companyId);
      if (data) onFinancialYear(data.map(item => ({ label: item.name, value: item.id })));
    } catch (error) {
      if (toast) apiErrorHandling(error, toast);
      else console.log(error);
    }
  };
  fetcher();
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
  onMappingSuccess,
  fetchCompanyFinancialYear
};
