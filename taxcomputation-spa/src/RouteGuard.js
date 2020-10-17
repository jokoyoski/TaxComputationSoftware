import React from "react";
import { useRouterActions } from "react-resource-router";
import constants from "./constants";
import { useAuth } from "./store/AuthStore";

export default Component => props => {
  const [{ isAuthenticated }] = useAuth();
  const { replace } = useRouterActions();

  React.useEffect(() => {
    if (isAuthenticated !== null && !isAuthenticated) replace(constants.routes.login);
  }, [isAuthenticated, replace]);

  return <>{isAuthenticated && <Component {...props} />}</>;
};
