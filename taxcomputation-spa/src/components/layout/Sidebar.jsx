import React from "react";
import { Link } from "react-resource-router";
import constants from "../../constants";

const Sidebar = ({ selectedTitle }) => {
  const menuItems = [
    { title: "Dashboard", href: constants.routes.dashboard },
    { title: "Fixed Asset" },
    { title: "Profit & Loss", href: constants.routes.profit_loss },
    { title: "Income Tax", href: constants.routes.income_tax },
    { title: "Deferred Tax", href: constants.routes.deferred_tax },
    { title: "Minimum Tax", href: constants.routes.minimum_tax },
    { title: "I.T Levy", href: constants.routes.it_levy },
    { title: "Capital Allowance", href: constants.routes.capital_allowance },
    { title: "Investment Allowance", href: constants.routes.investment_allowance },
    { title: "Balancing Adjustment", href: constants.routes.balancing_adjustment }
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
            <h4 style={{ marginTop: 5, marginBottom: 0 }}>John.Doe</h4>
            <p style={{ fontSize: 12, margin: 0 }}>Role: super admin</p>
          </div>
        </div>
        {menuItems.map((item, index) => (
          <Link
            key={index}
            href={item.href}
            style={{ padding: "5px 20px", textDecoration: "none", color: "inherit" }}>
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
        <div style={{ padding: "0px 20px" }}>
          <p style={{ margin: 0 }}>Logout</p>
        </div>
      </div>
    </div>
  );
};

export default Sidebar;
