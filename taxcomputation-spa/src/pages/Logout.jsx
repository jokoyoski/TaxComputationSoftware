import React from "react";
import { useAuth } from "../store/AuthStore";
import { useCompany } from "../store/CompanyStore";
import { useResources } from "../store/ResourcesStore";

const Logout = () => {
  const [, { onLogout }] = useAuth();
  const [, { resetCompany }] = useCompany();
  const [, { resetResources }] = useResources();

  React.useEffect(() => {
    onLogout(resetCompany, resetResources);
  }, [onLogout, resetCompany, resetResources]);

  return <></>;
};

export default Logout;
