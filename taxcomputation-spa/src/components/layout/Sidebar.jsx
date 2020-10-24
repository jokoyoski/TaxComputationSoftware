import React from "react";
import { Link } from "react-resource-router";
import constants from "../../constants";
import { useAuth } from "../../store/AuthStore";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";

const Sidebar = ({ selectedTitle }) => {
  const [{ firstName, lastName, email }, { onLogout }] = useAuth();
  const [{ companyId }, { resetCompany }] = useCompany();
  const menuItems = [
    { title: "Dashboard", href: constants.routes.dashboard },
    {
      title: constants.modules.fixedAsset,
      href: `${constants.routes.fixed_asset}/${utils.defaultMode(constants.modules.fixedAsset)}`
    },
    {
      title: constants.modules.profit_loss,
      href: `${constants.routes.profit_loss}/${utils.defaultMode(constants.modules.profit_loss)}`
    },
    {
      title: constants.modules.incomeTax,
      href: `${constants.routes.income_tax}/${utils.defaultMode(constants.modules.incomeTax)}`
    },
    {
      title: constants.modules.deferredTax,
      href: `${constants.routes.deferred_tax}/${utils.defaultMode(constants.modules.deferredTax)}`
    },
    {
      title: constants.modules.minimumTax,
      href: `${constants.routes.minimum_tax}/${utils.defaultMode(constants.modules.minimumTax)}`
    },
    {
      title: constants.modules.itLevy,
      href: `${constants.routes.it_levy}/${utils.defaultMode(constants.modules.itLevy)}`
    },
    {
      title: constants.modules.capitalAllowance,
      href: `${constants.routes.capital_allowance}/${utils.defaultMode(
        constants.modules.capitalAllowance
      )}`
    },
    {
      title: constants.modules.investmentAllowance,
      href: `${constants.routes.investment_allowance}/${utils.defaultMode(
        constants.modules.investmentAllowance
      )}`
    },
    {
      title: constants.modules.balancingAdjustment,
      href: `${constants.routes.balancing_adjustment}/${utils.defaultMode(
        constants.modules.balancingAdjustment
      )}`
    }
  ];

  return (
    <div className="p-d-flex" style={{ position: "fixed", zIndex: 1 }}>
      <div
        className="p-d-flex p-flex-column"
        style={{
          width: 256,
          height: "100vh",
          background: "#fff"
        }}>
        <h2 className="accent-color" style={{ margin: "5px 0", padding: "10px 20px" }}>
          Tax Computation
        </h2>
        <div className="divider"></div>
        <div style={{ padding: "10px 20px" }}>
          <div style={{ marginTop: 10, background: "#f5f6f8", padding: 10 }}>
            <h4 style={{ marginTop: 5, marginBottom: 0 }}>
              {firstName} {lastName}
            </h4>
            <p style={{ fontSize: 12, margin: 0 }}>{email}</p>
          </div>
        </div>
        {menuItems.map((item, index) => (
          <Link
            key={index}
            href={companyId ? item.href : null}
            className="sidebar-link"
            style={{ padding: "5px 20px" }}>
            <p
              className={
                selectedTitle.toLowerCase() === item.title.toLowerCase() ? "accent-color" : ""
              }
              style={{ marginTop: 5, marginBottom: 0 }}>
              {item.title}
            </p>
          </Link>
        ))}
        <div className="divider" style={{ margin: "10px 0px" }}></div>
        <div className="sidebar-link" style={{ padding: "0px 20px" }}>
          <p
            style={{ margin: 0, cursor: "pointer" }}
            onClick={() => {
              onLogout(resetCompany);
            }}>
            Logout
          </p>
        </div>
      </div>
    </div>
  );
};

export default Sidebar;
