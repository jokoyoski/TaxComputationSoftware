export default {
  startYear: 1980,
  toastLifeTime: 6000,
  modes: ["mapping", "view"],
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
    dashboard: "/dashboard",
    fixed_asset: "/fixed_asset",
    profit_loss: "/profit_loss",
    income_tax: "/income_tax",
    deferred_tax: "/deferred_tax",
    minimum_tax: "/minimum_tax",
    it_levy: "/it_levy",
    capital_allowance: "/capital_allowance",
    investment_allowance: "/investment_allowance",
    balancing_adjustment: "/balancing_adjustment"
  },
  nonMappedModules: ["Minimum Tax", "Capital Allowance", "Investment Allowance", "I.T Levy"],
  mappingCode: {
    fixedasset: "fixedasset",
    profitandloss: "profitandloss",
    balancingadjustment: "balancingadjustment",
    deferredtax: "deferredtax",
    incometax: "incometax"
  },
  networkErrorMessage: "Unable to reach server, check your network or contact your admin"
};
