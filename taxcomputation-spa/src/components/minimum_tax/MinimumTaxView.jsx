import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import utils from "../../utils";
import { minimumTaxViewData } from "../../apis/MinimumTax";
import ViewModeDataTable from "../common/ViewModeDataTable";

const MinimumTaxView = ({ year }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [minimumTaxData, setMinimumTaxData] = React.useState([]);

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
        if (isMounted.current) {
          if (error.response) setError(error.response.data.errors[0]);
          else setError(error.message);
        }
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchMinimumTaxViewData();

    return () => (isMounted.current = false);
  }, [companyId, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <ViewModeDataTable value={minimumTaxData}>
      <Column field="category" header=""></Column>
      <Column field="credit" header="₦"></Column>
    </ViewModeDataTable>
  );
};

export default MinimumTaxView;
