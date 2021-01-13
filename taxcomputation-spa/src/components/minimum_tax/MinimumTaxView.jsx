import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import { minimumTaxViewData } from "../../apis/MinimumTax";
import ViewModeDataTable from "../common/ViewModeDataTable";
import ViewLoader from "../common/ViewLoader";

const MinimumTaxView = ({ year, toast }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [minimumTaxData, setMinimumTaxData] = React.useState();

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;
    const fetchMinimumTaxViewData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await minimumTaxViewData({ companyId, year });
        if (isMounted.current) {
          setMinimumTaxData(() => {
            let newState = [];
            return newState.concat([
              {
                category: "0.5% OF TURNOVER",
                credit: utils.currencyFormatter(data.fivePercentTurnOver)
              },
              {
                category: "Dividend Income",
                credit: data.dividend ? utils.currencyFormatter(data.dividend) : null
              },
              {
                category: <strong>Minimum Tax Payable</strong>,
                credit: utils.currencyFormatter(data.turnOver)
              }
            ]);
          });
        }
      } catch (error) {
        let errorString = utils.apiErrorHandling(error, toast);
        setError(errorString);
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchMinimumTaxViewData();

    return () => (isMounted.current = false);
  }, [companyId, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  return (
    <>
      {minimumTaxData && (
        <ViewModeDataTable value={minimumTaxData}>
          <Column field="category" header=""></Column>
          <Column field="credit" header="₦"></Column>
        </ViewModeDataTable>
      )}
      {loading && <ViewLoader />}
    </>
  );
};

export default MinimumTaxView;
