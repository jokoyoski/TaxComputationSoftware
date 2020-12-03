import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import { profitAndLossViewData } from "../../apis/ProfitAndLoss";

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
    <DataTable
      className="p-datatable-gridlines"
      value={profitAndLossApiData}
      style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="total" header="Total"></Column>
    </DataTable>
  );
};

export default ProfitAndLossView;
