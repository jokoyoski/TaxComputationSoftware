export default {
  startYear: 1980,
  toastLifeTime: 6000,
  modes: ["adding", "mapping", "view", "summary"],
  minimumTaxType: {
    old: 0,
    new: 1
  },
  modules: {
    dashboard: "Dashboard",
    fixedAsset: "Fixed Asset",
    profit_loss: "Profit & Loss",
    incomeTax: "Income Tax",
    deferredTax: "Deferred Tax",
    minimumTax: "Minimum Tax",
    itLevy: "I.T Levy",
    capitalAllowance: "Capital Allowance",
    investmentAllowance: "Investment Allowance",
    balancingAdjustment: "Balancing Adjustment"
  },
  routes: {
    home: "/",
    login: "/login",
    forgot_password: "/forgot_password",
    reset_password: "/reset_password",
    dashboard: "/dashboard",
    fixed_asset: "/fixed_asset",
    profit_loss: "/profit_loss",
    income_tax: "/income_tax",
    deferred_tax: "/deferred_tax",
    minimum_tax: "/minimum_tax",
    it_levy: "/it_levy",
    capital_allowance: "/capital_allowance",
    investment_allowance: "/investment_allowance",
    balancing_adjustment: "/balancing_adjustment",
    logout: "/logout"
  },
  nonMappedModules: ["Income Tax", "Deferred Tax", "I.T Levy"],
  mappingCode: {
    fixedasset: "fixedasset",
    profitandloss: "profitandloss",
    balancingadjustment: "balancingadjustment"
    // deferredtax: "deferredtax",
    // incometax: "incometax"
  },
  networkErrorMessage: "Unable to reach server, check your network or contact your admin"
};
