import { createStore, createHook } from "react-sweet-state";

const initialState = {
  companies: null,
  fixedAssetModuleItems: null,
  profitAndLossModuleItems: null,
  trialBalance: null,
  assetList: null,
  selectedAsset: null,
  financialYears: [],
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
    onSelectedAsset: selectedAsset => ({ setState }) => setState({ selectedAsset }),
    onFinancialYear: financialYears => ({ setState }) => setState({ financialYears }),
    onSelectedFinancialYear: selectedFinancialYear => ({ setState }) =>
      setState({ selectedFinancialYear }),
    resetResources: () => ({ setState }) => setState(initialState)
  },
  name: "resources"
});

export const useResources = createHook(ResourcesStore);
