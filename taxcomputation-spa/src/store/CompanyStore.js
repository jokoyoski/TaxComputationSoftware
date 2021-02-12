import { createStore, createHook } from "react-sweet-state";

const initialState = {
  companyId: null,
  companyName: "",
  companyDescription: "",
  cacNumber: "",
  tinNumber: ""
};

const CompanyStore = createStore({
  initialState,
  actions: {
    initCompany: initialState => ({ setState }) => setState(initialState),
    onSelectCompany: ({ companyId, companyName, companyDescription, cacNumber, tinNumber }) => ({
      setState
    }) => setState({ companyId, companyName, companyDescription, cacNumber, tinNumber }),
    resetCompany: () => ({ setState }) => setState({ ...initialState })
  },
  name: "company"
});

export const useCompany = createHook(CompanyStore);
