import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import { balancingAdjustmentViewData } from "../../apis/BalancingAdjustment";
import utils from "../../utils";
import Loader from "../common/Loader";

const BalancingAdjustmentView = ({ year }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [balancingAdjustmentData, setBalancingAdjustmentData] = React.useState([]);

  React.useEffect(() => {
    isMounted.current = true;
    const fetchBalancingAdjustmentViewData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await balancingAdjustmentViewData({ companyId, year });
        if (isMounted.current) {
          setBalancingAdjustmentData(() => {
            const tableData = [];
            data.values.balancingAdjustments.forEach((d, index) => {
              const assetNameRow = {};
              const costRow = {};
              const initialAllowanceRow = {};
              const annualAllowanceRow = {};
              const residueRow = {};
              const salesProceedRow = {};
              const balanceRow = {};
              const emptyRow = {};

              assetNameRow.category = <strong>{d.assetName}</strong>;

              costRow.category = `Cost up to ${d.assetYear[0].yearBought} YOA`;
              costRow.credit = utils.currencyFormatter(d.assetYear[0].cost);
              costRow.cost = utils.currencyFormatter(d.assetYear[0].cost);

              initialAllowanceRow.category = "Initial Allowance";
              initialAllowanceRow.credit = utils.currencyFormatter(d.assetYear[0].initialAllowance);

              annualAllowanceRow.category = `Annual allowances up to ${year - 1}`;
              annualAllowanceRow.credit = utils.currencyFormatter(d.assetYear[0].annualAllowance);

              residueRow.category = `Residue at 31.12.${year - 1}`;
              residueRow.credit = utils.currencyFormatter(d.assetYear[0].residue);
              residueRow.twdv = utils.currencyFormatter(d.assetYear[0].residue);

              salesProceedRow.category = "Sales Proceeds";
              salesProceedRow.credit = utils.currencyFormatter(d.assetYear[0].salesProceed);
              salesProceedRow.salesProceed = utils.currencyFormatter(d.assetYear[0].salesProceed);

              if (d.balancingCharge > 0) {
                balanceRow.category = "Balancing Charge";
                balanceRow.credit = utils.currencyFormatter(d.assetYear[0].balancingCharge);
                balanceRow.balancingCharge = utils.currencyFormatter(
                  d.assetYear[0].balancingCharge
                );
              } else {
                balanceRow.category = "Balancing Allowance";
                balanceRow.credit = utils.currencyFormatter(d.assetYear[0].balancingAllowance);
                balanceRow.balancingCharge = utils.currencyFormatter(
                  d.assetYear[0].balancingAllowance
                );
              }

              tableData.push(assetNameRow);
              tableData.push(costRow);
              tableData.push(initialAllowanceRow);
              tableData.push(annualAllowanceRow);
              tableData.push(residueRow);
              tableData.push(salesProceedRow);
              tableData.push(balanceRow);
              if (index < data.values.balancingAdjustments.length - 1) tableData.push(emptyRow);
            });
            return tableData;
          });
        }
      } catch (error) {
        if (isMounted.current) {
          if (error.response) setError(error.response.data.errors[0]);
          else setError(error.message);
        }
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchBalancingAdjustmentViewData();

    return () => (isMounted.current = false);
  }, [companyId, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  if (balancingAdjustmentData.length === 0)
    return <p style={{ color: "#f00" }}>Currently, no data for the selected company</p>;

  return (
    <DataTable
      value={balancingAdjustmentData}
      className="p-datatable-gridlines"
      style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="credit" header=""></Column>
      <Column field="balancingAllowance" header="Balancing Allowance"></Column>
      <Column field="balancingCharge" header="Balancing Charge"></Column>
      <Column field="cost" header="Cost"></Column>
      <Column field="salesProceed" header="Sales Proceed"></Column>
      <Column field="twdv" header="TWDV"></Column>
    </DataTable>
  );
};

export default BalancingAdjustmentView;
