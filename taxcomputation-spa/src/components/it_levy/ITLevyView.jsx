import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import { itLevyViewData } from "../../apis/ITLevy";
import utils from "../../utils";
import ViewModeDataTable from "../common/ViewModeDataTable";
import ViewLoader from "../common/ViewLoader";

const ITLevyView = ({ year, toast }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [itLevyData, setITLevyData] = React.useState();

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;
    const fetchITLevyViewData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await itLevyViewData({ companyId, year });
        if (isMounted.current) {
          setITLevyData(() => {
            let newState = [];
            return newState.concat([
              {
                category: "Profit Before Taxation",
                credit: utils.currencyFormatter(data.profitBeforeTaxation)
              },
              {
                category: "I.T. Levy @ 1% Thereon",
                credit: utils.currencyFormatter(data.itLevyAt1PercentThereIn)
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
    fetchITLevyViewData();

    return () => (isMounted.current = false);
  }, [companyId, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  return (
    <>
      {itLevyData && (
        <ViewModeDataTable value={itLevyData}>
          <Column field="category" header=""></Column>
          <Column field="credit" header="₦"></Column>
        </ViewModeDataTable>
      )}
      {loading && <ViewLoader />}
    </>
  );
};

export default ITLevyView;
