import { createStore, createHook } from "react-sweet-state";

const AuthStore = createStore({
  // value of the store on initialisation
  initialState: {
    isAuthenticated: null,
    userId: null,
    token: "",
    email: "",
    firstName: "",
    lastName: ""
  },
  // actions that trigger store mutation
  actions: {
    initAuth: initialState => ({ setState, getState }) => {
      setState(initialState);
      if (getState().isAuthenticated === null) {
        setState({ isAuthenticated: false });
      }
    },
    onLoginSuccess: ({ id: userId, token, email, firstName, lastName }) => ({ setState }) => {
      // mutate state syncronously
      setState({ isAuthenticated: true, userId, token, email, firstName, lastName });
    },
    onLogout: () => ({ setState }) => {
      setState({ isAuthenticated: false });
    }
  },
  // optional, mostly used for easy debugging
  name: "auth"
});

export const useAuth = createHook(AuthStore);
