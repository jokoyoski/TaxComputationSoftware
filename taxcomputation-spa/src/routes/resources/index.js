import { createResource } from "react-resource-router";
import { getCompanies } from "../../apis/Companies";

export const companiesResource = createResource({
  type: "COMPANIES",
  getKey: () => "companies",
  getData: () => getCompanies()
});
