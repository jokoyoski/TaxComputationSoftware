import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import { profitAndLossViewData } from "../../apis/ProfitAndLoss";
import ViewModeDataTable from "../common/ViewModeDataTable";

const ProfitAndLossView = ({ year }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [profitAndLossApiData, setProfitAndLossApiData] = React.useState([]);

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
        if (isMounted.current) {
          if (error.response) setError(error.response.data.errors[0]);
          else setError(error.message);
        }
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchProfitAndLossViewData();

    return () => (isMounted.current = false);
  }, [companyId, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <ViewModeDataTable value={profitAndLossApiData}>
      <Column field="category" header=""></Column>
      <Column field="total" header="Total"></Column>
    </ViewModeDataTable>
  );
};

export default ProfitAndLossView;
