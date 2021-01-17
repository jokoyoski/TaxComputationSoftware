import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import { minimumTaxViewData } from "../../apis/MinimumTax";
import ViewModeDataTable from "../common/ViewModeDataTable";
import ViewLoader from "../common/ViewLoader";

const MinimumTaxView = ({ year, toast, percentageTurnOver, setPercentageTurnOver }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [minimumTaxData, setMinimumTaxData] = React.useState();

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;
    const fetchMinimumTaxViewData = async () => {
      if (!percentageTurnOver.canQuery) return;
      else if (isNaN(percentageTurnOver.value)) {
        toast.show(
          utils.toastCallback({
            severity: "error",
            detail: "Percentage Turn Over is not a number"
          })
        );
      }

      try {
        setError(null);
        setLoading(true);
        setPercentageTurnOver(state => ({ ...state, canQuery: null }));
        const data = await minimumTaxViewData({
          companyId,
          year,
          percentageTurnOver: Number(percentageTurnOver.value)
        });
        if (isMounted.current) {
          setMinimumTaxData(() => {
            let newState = [];
            return newState.concat([
              {
                category: `${percentageTurnOver.value}% OF TURNOVER`,
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
        if (isMounted.current) {
          setLoading(false);
          setPercentageTurnOver(state => ({ ...state, canQuery: false }));
        }
      }
    };
    fetchMinimumTaxViewData();

    return () => (isMounted.current = false);
  }, [companyId, percentageTurnOver, setPercentageTurnOver, toast, year]);

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
