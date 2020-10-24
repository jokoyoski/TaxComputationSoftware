import constants from "../constants";
import BalancingAdjustment from "../pages/BalancingAdjustment";
import CapitalAllowance from "../pages/CapitalAllowance";
import Dashboard from "../pages/Dashboard";
import DeferredTax from "../pages/DeferredTax";
import FixedAsset from "../pages/FixedAsset";
import ForgotPassword from "../pages/ForgotPassword";
import Home from "../pages/Home";
import IncomeTax from "../pages/IncomeTax";
import InvestmentAllowance from "../pages/InvestmentAllowance";
import ITLevy from "../pages/ITLevy";
import Login from "../pages/Login";
import MinimumTax from "../pages/MinimumTax";
import NotFound from "../pages/NotFound";
import ProfitLoss from "../pages/ProfitLoss";
import ResetPassword from "../pages/ResetPassword";
import RouteGuard from "../RouteGuard";
import { assetClassResource, companiesResource, trialBalanceResource } from "./resources";

const modePathParam = "/:mode";

export const routes = [
  {
    path: constants.routes.home,
    name: "HOME",
    exact: true,
    component: Home
  },
  {
    path: constants.routes.login,
    name: "LOGIN",
    exact: true,
    component: Login
  },
  {
    path: constants.routes.forgot_password,
    name: "FORGOT_PASSWORD",
    exact: true,
    component: ForgotPassword
  },
  {
    path: constants.routes.reset_password,
    name: "RESET_PASSWORD",
    exact: true,
    component: ResetPassword
  },
  {
    path: constants.routes.dashboard,
    name: "DASHBOARD",
    exact: true,
    component: RouteGuard(Dashboard),
    resources: [companiesResource]
  },
  {
    path: `${constants.routes.fixed_asset}${modePathParam}`,
    name: "FIXED_ASSET",
    exact: true,
    component: RouteGuard(FixedAsset),
    resources: [assetClassResource, trialBalanceResource]
  },
  {
    path: `${constants.routes.profit_loss}${modePathParam}`,
    name: "PROFIT_LOSS",
    exact: true,
    component: RouteGuard(ProfitLoss)
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.income_tax}${modePathParam}`,
    name: "INCOME_TAX",
    exact: true,
    component: RouteGuard(IncomeTax)
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.deferred_tax}${modePathParam}`,
    name: "DEFERRED_TAX",
    exact: true,
    component: RouteGuard(DeferredTax)
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.minimum_tax}${modePathParam}`,
    name: "MINIMUM_TAX",
    exact: true,
    component: RouteGuard(MinimumTax)
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.it_levy}${modePathParam}`,
    name: "IT_LEVY",
    exact: true,
    component: RouteGuard(ITLevy)
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.capital_allowance}${modePathParam}`,
    name: "CAPITAL_ALLOWANCE",
    exact: true,
    component: RouteGuard(CapitalAllowance)
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.investment_allowance}${modePathParam}`,
    name: "INVESTMENT_ALLOWANCE",
    exact: true,
    component: RouteGuard(InvestmentAllowance)
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.balancing_adjustment}${modePathParam}`,
    name: "BALANCING_ADJUSTMENT",
    exact: true,
    component: RouteGuard(BalancingAdjustment)
    //resources: [aboutResource],
  },
  {
    path: "*",
    name: "NOT_FOUND",
    component: NotFound
  }
];
