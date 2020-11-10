import { createStore, createHook } from "react-sweet-state";

const ResourcesStore = createStore({
  initialState: {
    companies: null,
    moduleItems: null,
    trialBalance: null
  },
  actions: {
    initResource: initialState => ({ setState }) => setState(initialState),
    onCompanies: companies => ({ setState }) => setState({ companies }),
    onModuleItems: moduleItems => ({ setState }) => setState({ moduleItems }),
    onTrialBalance: trialBalance => ({ setState }) => setState({ trialBalance }),
    resetResources: () => ({ setState }) =>
      setState({
        companies: null,
        moduleItems: null,
        trialBalance: null
      })
  },
  name: "resources"
});

export const useResources = createHook(ResourcesStore);
