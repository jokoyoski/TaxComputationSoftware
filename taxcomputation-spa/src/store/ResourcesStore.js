import { createStore, createHook } from "react-sweet-state";

const ResourcesStore = createStore({
  initialState: {
    companies: null,
    fixedAssetModuleItems: null,
    profitAndLossModuleItems: null,
    trialBalance: null
  },
  actions: {
    initResource: initialState => ({ setState }) => setState(initialState),
    onCompanies: companies => ({ setState }) => setState({ companies }),
    onFixedAssetModuleItems: fixedAssetModuleItems => ({ setState }) =>
      setState({ fixedAssetModuleItems }),
    onProfitAndLossModuleItems: profitAndLossModuleItems => ({ setState }) =>
      setState({ profitAndLossModuleItems }),
    onTrialBalance: trialBalance => ({ setState }) => setState({ trialBalance }),
    resetResources: () => ({ setState }) =>
      setState({
        companies: null,
        fixedAssetModuleItems: null,
        profitAndLossModuleItems: null,
        trialBalance: null
      })
  },
  name: "resources"
});

export const useResources = createHook(ResourcesStore);
