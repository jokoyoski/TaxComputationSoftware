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
            data.values.balancingAdjustments.forEach((balancingAdjustment, index) => {
              const assetNameRow = {};
              const emptyRow = {};

              assetNameRow.category = <strong>{balancingAdjustment.assetName}</strong>;

              tableData.push(assetNameRow);

              balancingAdjustment.assetYear.forEach((assetYear, index) => {
                const costRow = {};
                const initialAllowanceRow = {};
                const annualAllowanceRow = {};
                const residueRow = {};
                const salesProceedRow = {};
                const balanceRow = {};

                costRow.category = `Cost up to ${assetYear.yearBought} YOA`;
                costRow.credit = utils.currencyFormatter(assetYear.cost);
                costRow.cost = utils.currencyFormatter(assetYear.cost);

                initialAllowanceRow.category = "Initial Allowance";
                initialAllowanceRow.credit = utils.currencyFormatter(assetYear.initialAllowance);

                annualAllowanceRow.category = `Annual allowances up to ${year - 1}`;
                annualAllowanceRow.credit = utils.currencyFormatter(assetYear.annualAllowance);

                residueRow.category = `Residue at 31.12.${year - 1}`;
                residueRow.credit = utils.currencyFormatter(assetYear.residue);
                residueRow.twdv = utils.currencyFormatter(assetYear.residue);

                salesProceedRow.category = "Sales Proceeds";
                salesProceedRow.credit = utils.currencyFormatter(assetYear.salesProceed);
                salesProceedRow.salesProceed = utils.currencyFormatter(assetYear.salesProceed);

                if (assetYear.balancingCharge > 0) {
                  balanceRow.category = "Balancing Charge";
                  balanceRow.credit = utils.currencyFormatter(assetYear.balancingCharge);
                  balanceRow.balancingCharge = utils.currencyFormatter(assetYear.balancingCharge);
                } else {
                  balanceRow.category = "Balancing Allowance";
                  balanceRow.credit = utils.currencyFormatter(assetYear.balancingAllowance);
                  balanceRow.balancingCharge = utils.currencyFormatter(
                    assetYear.balancingAllowance
                  );
                }

                tableData.push(costRow);
                tableData.push(initialAllowanceRow);
                tableData.push(annualAllowanceRow);
                tableData.push(residueRow);
                tableData.push(salesProceedRow);
                tableData.push(balanceRow);
                if (index < balancingAdjustment.assetYear.length - 1) tableData.push(emptyRow);
              });

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
