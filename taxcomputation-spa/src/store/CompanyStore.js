import { createStore, createHook } from "react-sweet-state";

const initialState = {
  companyId: null,
  companyName: "",
  companyDescription: "",
  cacNumber: "",
  tinNumber: "",
  minimumTaxTypeId: null
};

const CompanyStore = createStore({
  initialState,
  actions: {
    initCompany: initialState => ({ setState }) => setState(initialState),
    onSelectCompany: ({
      companyId,
      companyName,
      companyDescription,
      cacNumber,
      tinNumber,
      minimumTaxTypeId
    }) => ({ setState }) =>
      setState({
        companyId,
        companyName,
        companyDescription,
        cacNumber,
        tinNumber,
        minimumTaxTypeId
      }),
    resetCompany: () => ({ setState }) => setState({ ...initialState })
  },
  name: "company"
});

export const useCompany = createHook(CompanyStore);
