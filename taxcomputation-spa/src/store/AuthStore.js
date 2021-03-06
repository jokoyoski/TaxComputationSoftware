import { createStore, createHook } from "react-sweet-state";

const AuthStore = createStore({
  initialState: {
    isAuthenticated: null,
    userId: null,
    token: "",
    email: "",
    firstName: "",
    lastName: ""
  },
  actions: {
    initAuth: initialState => ({ setState, getState }) => {
      setState(initialState);
      if (getState().isAuthenticated === null) {
        setState({ isAuthenticated: false });
      }
    },
    onLoginSuccess: ({ id: userId, token, email, firstName, lastName }) => ({ setState }) =>
      setState({ isAuthenticated: true, userId, token, email, firstName, lastName }),
    onLogout: (...callbacks) => ({ setState }) => {
      callbacks.forEach(cb => (cb instanceof Function ? cb() : null));
      setState({
        isAuthenticated: false,
        userId: null,
        token: "",
        email: "",
        firstName: "",
        lastName: ""
      });
    }
  },
  name: "auth"
});

export const useAuth = createHook(AuthStore);
