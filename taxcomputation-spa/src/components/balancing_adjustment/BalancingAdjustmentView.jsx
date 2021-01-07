import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import {
  balancingAdjustmentDelete,
  balancingAdjustmentViewData
} from "../../apis/BalancingAdjustment";
import utils from "../../utils";
import Loader from "../common/Loader";
import ViewModeDataTable from "../common/ViewModeDataTable";

const BalancingAdjustmentView = ({ year, toast }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [balancingAdjustmentData, setBalancingAdjustmentData] = React.useState([]);

  React.useEffect(() => {
    if (!companyId) return;

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

                costRow.category = (
                  <div className="p-d-flex p-jc-between p-ai-center">
                    <p>{`Cost up to ${assetYear.yearBought} YOA`}</p>
                    <i
                      className="pi pi-times-circle delete"
                      style={{ fontSize: 14, marginTop: 2 }}
                      onClick={async () => {
                        try {
                          const data = await balancingAdjustmentDelete(assetYear.id);
                          if (data) {
                            toast.show(
                              utils.toastCallback({
                                severity: "success",
                                detail: data.responseDescription
                              })
                            );
                            fetchBalancingAdjustmentViewData();
                          }
                        } catch (error) {
                          console.log(error);
                        }
                      }}></i>
                  </div>
                );
                costRow.credit = utils.currencyFormatter(assetYear.cost);
                costRow.cost = utils.currencyFormatter(assetYear.cost);

                initialAllowanceRow.category = "Initial Allowance";
                initialAllowanceRow.credit = utils.currencyFormatter(assetYear.initialAllowance);

                annualAllowanceRow.category = `Annual allowances`;
                annualAllowanceRow.credit = utils.currencyFormatter(assetYear.annualAllowance);

                residueRow.category = `Residue`;
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
  }, [companyId, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  if (balancingAdjustmentData?.length === 0 || balancingAdjustmentData === undefined)
    return (
      <p style={{ color: "#f00" }}>Currently, no data for the selected year for this company</p>
    );

  return (
    <ViewModeDataTable value={balancingAdjustmentData}>
      <Column field="category" header=""></Column>
      <Column field="credit" header=""></Column>
      <Column field="balancingAllowance" header="Balancing Allowance"></Column>
      <Column field="balancingCharge" header="Balancing Charge"></Column>
      <Column field="cost" header="Cost"></Column>
      <Column field="salesProceed" header="Sales Proceed"></Column>
      <Column field="twdv" header="TWDV"></Column>
    </ViewModeDataTable>
  );
};

export default BalancingAdjustmentView;
