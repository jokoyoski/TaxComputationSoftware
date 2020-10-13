import constants from "../constants";
import BalancingAdjustment from "../pages/BalancingAdjustment";
import CapitalAllowance from "../pages/CapitalAllowance";
import Dashboard from "../pages/Dashboard";
import DeferredTax from "../pages/DeferredTax";
import Home from "../pages/Home";
import IncomeTax from "../pages/IncomeTax";
import InvestmentAllowance from "../pages/InvestmentAllowance";
import ITLevy from "../pages/ITLevy";
import Login from "../pages/Login";
import MinimumTax from "../pages/MinimumTax";
import ProfitLoss from "../pages/ProfitLoss";

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
    path: constants.routes.profit_loss,
    name: "PROFIT_LOSS",
    exact: true,
    component: ProfitLoss
    //resources: [aboutResource],
  },
  {
    path: constants.routes.income_tax,
    name: "INCOME_TAX",
    exact: true,
    component: IncomeTax
    //resources: [aboutResource],
  },
  {
    path: constants.routes.deferred_tax,
    name: "DEFERRED_TAX",
    exact: true,
    component: DeferredTax
    //resources: [aboutResource],
  },
  {
    path: constants.routes.minimum_tax,
    name: "MINIMUM_TAX",
    exact: true,
    component: MinimumTax
    //resources: [aboutResource],
  },
  {
    path: constants.routes.it_levy,
    name: "IT_LEVY",
    exact: true,
    component: ITLevy
    //resources: [aboutResource],
  },
  {
    path: constants.routes.capital_allowance,
    name: "CAPITAL_ALLOWANCE",
    exact: true,
    component: CapitalAllowance
    //resources: [aboutResource],
  },
  {
    path: constants.routes.investment_allowance,
    name: "INVESTMENT_ALLOWANCE",
    exact: true,
    component: InvestmentAllowance
    //resources: [aboutResource],
  },
  {
    path: constants.routes.balancing_adjustment,
    name: "BALANCING_ADJUSTMENT",
    exact: true,
    component: BalancingAdjustment
    //resources: [aboutResource],
  }
];
