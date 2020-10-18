import { createStore, createHook } from "react-sweet-state";

const CompanyStore = createStore({
  initialState: {
    companyId: null,
    companyName: "",
    companyDescription: "",
    cacNumber: "",
    tinNumber: ""
  },
  actions: {
    initCompany: initialState => ({ setState }) => setState(initialState),
    onSelectCompany: ({ companyId, companyName, companyDescription, cacNumber, tinNumber }) => ({
      setState
    }) => setState({ companyId, companyName, companyDescription, cacNumber, tinNumber })
  },
  name: "company"
});

export const useCompany = createHook(CompanyStore);
