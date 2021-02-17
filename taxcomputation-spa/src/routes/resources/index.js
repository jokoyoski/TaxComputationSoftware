import { createResource } from "react-resource-router";
import { getCompanies } from "../../apis/Companies";
import { getTrialBalance } from "../../apis/TrialBalance";
import { getCompanyFinancialYear, getModuleItems } from "../../apis/Utilities";

export const companiesResource = createResource({
  type: "COMPANIES",
  getKey: () => "companies",
  getData: () => getCompanies()
});

export const fixedAssetModuleClassResource = createResource({
  type: "FIXED_ASSET_MODULE_CLASS",
  getKey: () => "fixedAssetModuleClass",
  getData: () => getModuleItems({ moduleCode: "fixedasset" })
});

export const profitandlossModuleClassResource = createResource({
  type: "PROFIT_AND_LOSS_MODULE_CLASS",
  getKey: () => "profitandlossModuleClass",
  getData: () => getModuleItems({ moduleCode: "profitandloss" })
});

export const trialBalanceResource = createResource({
  type: "TRIAL_BALANCE",
  getKey: () => "trialBalance",
  getData: () =>
    getTrialBalance({
      companyId: sessionStorage.getItem("cid"),
      year: sessionStorage.getItem("yid")
    })
});

export const companyFinancialYearResource = createResource({
  type: "COMPANY_FINANCIAL_YEAR",
  getKey: () => "companyFinancialYear",
  getData: () => getCompanyFinancialYear(sessionStorage.getItem("cid"))
});
