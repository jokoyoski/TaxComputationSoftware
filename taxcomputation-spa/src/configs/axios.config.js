import axios from "axios";
// import { login } from 'routes';
// import { refreshTokenAuth, signOut } from 'store/actions/auth';
// import store from 'store/store';

export default function () {
  // set axios base url
  axios.defaults.baseURL = window.configs.baseURL;
  // Request interceptor for API calls
  // axios.interceptors.request.use(
  //   config => {
  //     const token = store.getState().auth.accessToken;

  //     if (token) {
  //       config.headers['Authorization'] = `Bearer ${token}`;
  //     }

  //     return config;
  //   },
  //   error => {
  //     Promise.reject(error);
  //   }
  // );
}
