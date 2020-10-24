import { createResource } from "react-resource-router";
import { getCompanies } from "../../apis/Companies";
import { getTrialBalance } from "../../apis/TrialBalance";
import { getAssetClass } from "../../apis/Utilities";
import utils from "../../utils";

export const companiesResource = createResource({
  type: "COMPANIES",
  getKey: () => "companies",
  getData: () => getCompanies()
});

export const assetClassResource = createResource({
  type: "ASSET_CLASS",
  maxAge: 300000,
  getKey: () => "assetClass",
  getData: () => getAssetClass()
});

export const trialBalanceResource = createResource({
  type: "TRIAL_BALANCE",
  maxAge: 300000,
  getKey: () => "trialBalance",
  getData: () =>
    getTrialBalance({ companyId: sessionStorage.getItem("cid"), year: utils.currentYear() })
});
