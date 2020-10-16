export default {
  startYear: 1980,
  modes: ["mapping", "view"],
  modules: {
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
    profit_loss: "/profit_loss",
    income_tax: "/income_tax",
    deferred_tax: "/deferred_tax",
    minimum_tax: "/minimum_tax",
    it_levy: "/it_levy",
    capital_allowance: "/capital_allowance",
    investment_allowance: "/investment_allowance",
    balancing_adjustment: "/balancing_adjustment"
  },
  nonMappedModules: ["Minimum Tax", "Capital Allowance", "Investment Allowance"],
  mappingCode: {
    fixedasset: "fixedasset",
    profitandloss: "profitandloss",
    balancingadjustment: "balancingadjustment",
    deferredtax: "deferredtax",
    incometax: "incometax"
  }
};
