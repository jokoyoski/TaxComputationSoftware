import React from "react";
import { useRouter } from "react-resource-router";
import constants from "./constants";
import { useAuth } from "./store/AuthStore";

export default Component => props => {
  const [{ isAuthenticated }] = useAuth();
  const [routerState, { replace }] = useRouter();

  React.useEffect(() => {
    if (isAuthenticated !== null && !isAuthenticated)
      replace({ pathname: constants.routes.login, state: routerState.location.state });
  }, [isAuthenticated, replace, routerState]);

  return <>{isAuthenticated && <Component {...props} />}</>;
};
