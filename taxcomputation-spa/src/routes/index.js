import constants from "../constants";
import BalancingAdjustment from "../pages/BalancingAdjustment";
import CapitalAllowance from "../pages/CapitalAllowance";
import Dashboard from "../pages/Dashboard";
import DeferredTax from "../pages/DeferredTax";
import FixedAsset from "../pages/FixedAsset";
import Home from "../pages/Home";
import IncomeTax from "../pages/IncomeTax";
import InvestmentAllowance from "../pages/InvestmentAllowance";
import ITLevy from "../pages/ITLevy";
import Login from "../pages/Login";
import MinimumTax from "../pages/MinimumTax";
import NotFound from "../pages/NotFound";
import ProfitLoss from "../pages/ProfitLoss";

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
    path: constants.routes.dashboard,
    name: "DASHBOARD",
    exact: true,
    component: Dashboard
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.fixed_asset}${modePathParam}`,
    name: "FIXED_ASSET",
    exact: true,
    component: FixedAsset
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.profit_loss}${modePathParam}`,
    name: "PROFIT_LOSS",
    exact: true,
    component: ProfitLoss
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.income_tax}${modePathParam}`,
    name: "INCOME_TAX",
    exact: true,
    component: IncomeTax
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.deferred_tax}${modePathParam}`,
    name: "DEFERRED_TAX",
    exact: true,
    component: DeferredTax
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.minimum_tax}${modePathParam}`,
    name: "MINIMUM_TAX",
    exact: true,
    component: MinimumTax
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.it_levy}${modePathParam}`,
    name: "IT_LEVY",
    exact: true,
    component: ITLevy
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.capital_allowance}${modePathParam}`,
    name: "CAPITAL_ALLOWANCE",
    exact: true,
    component: CapitalAllowance
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.investment_allowance}${modePathParam}`,
    name: "INVESTMENT_ALLOWANCE",
    exact: true,
    component: InvestmentAllowance
    //resources: [aboutResource],
  },
  {
    path: `${constants.routes.balancing_adjustment}${modePathParam}`,
    name: "BALANCING_ADJUSTMENT",
    exact: true,
    component: BalancingAdjustment
    //resources: [aboutResource],
  },
  {
    path: "*",
    name: "NOT_FOUND",
    component: NotFound
  }
];
