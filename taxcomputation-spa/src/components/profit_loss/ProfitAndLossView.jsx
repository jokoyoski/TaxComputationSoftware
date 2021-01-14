import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import { profitAndLossViewData } from "../../apis/ProfitAndLoss";
import ViewModeDataTable from "../common/ViewModeDataTable";
import utils from "../../utils";
import ViewLoader from "../common/ViewLoader";

const ProfitAndLossView = ({ year, toast }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [profitAndLossApiData, setProfitAndLossApiData] = React.useState();

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;
    const fetchProfitAndLossViewData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await profitAndLossViewData({ companyId, year });
        if (isMounted.current) {
          setProfitAndLossApiData(data);
        }
      } catch (error) {
        let errorString = utils.apiErrorHandling(error, toast);
        setError(errorString);
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchProfitAndLossViewData();

    return () => (isMounted.current = false);
  }, [companyId, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  return (
    <>
      {profitAndLossApiData && (
        <ViewModeDataTable value={profitAndLossApiData}>
          <Column field="category" header=""></Column>
          <Column field="total" header="Total"></Column>
        </ViewModeDataTable>
      )}
      {loading && <ViewLoader />}
    </>
  );
};

export default ProfitAndLossView;
