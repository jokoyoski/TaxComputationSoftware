import { createStore, createHook } from "react-sweet-state";

const initialState = {
  companies: null,
  fixedAssetModuleItems: null,
  profitAndLossModuleItems: null,
  trialBalance: null,
  assetList: null,
  companyList: null,
  selectedAsset: null,
  selectedCompany: null,
  financialYears: null,
  selectedFinancialYear: null
};

const ResourcesStore = createStore({
  initialState,
  actions: {
    initResource: initialState => ({ setState }) => setState(initialState),
    onCompanies: companies => ({ setState }) => setState({ companies }),
    onFixedAssetModuleItems: fixedAssetModuleItems => ({ setState }) =>
      setState({ fixedAssetModuleItems }),
    onProfitAndLossModuleItems: profitAndLossModuleItems => ({ setState }) =>
      setState({ profitAndLossModuleItems }),
    onTrialBalance: trialBalance => ({ setState }) => setState({ trialBalance }),
    onAssetList: assetList => ({ setState }) => setState({ assetList }),
    onCompanyList: companyList => ({ setState }) => setState({ companyList }),
    onSelectedAsset: selectedAsset => ({ setState }) => setState({ selectedAsset }),
    onSelectedCompany: selectedCompany => ({ setState }) => setState({ selectedCompany }),
    onFinancialYear: financialYears => ({ setState }) => setState({ financialYears }),
    onSelectedFinancialYear: selectedFinancialYear => ({ setState }) =>
      setState({ selectedFinancialYear }),
    resetResources: () => ({ setState }) => setState({ ...initialState })
  },
  name: "resources"
});

export const useResources = createHook(ResourcesStore);
