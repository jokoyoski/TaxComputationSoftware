import React from "react";
import { useRouter } from "react-resource-router";
import constants from "./constants";
import { useAuth } from "./store/AuthStore";
import { Toast } from "primereact/toast";

export default Component => props => {
  const [{ isAuthenticated }] = useAuth();
  const [routerState, { replace }] = useRouter();
  const toast = React.useRef();

  React.useEffect(() => {
    if (isAuthenticated !== null && !isAuthenticated)
      replace({ pathname: constants.routes.login, state: routerState.location.state });
  }, [isAuthenticated, replace, routerState]);

  return (
    <>
      {isAuthenticated && (
        <>
          <Component {...props} toast={toast.current} />
          <Toast baseZIndex={1000} ref={el => (toast.current = el)} />
        </>
      )}
    </>
  );
};
