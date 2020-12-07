import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import { itLevyViewData } from "../../apis/ITLevy";
import utils from "../../utils";

const ITLevyView = ({ year }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [itLevyData, setITLevyData] = React.useState([]);

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
        if (isMounted.current) {
          if (error.response) setError(error.response.data.errors[0]);
          else setError(error.message);
        }
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchITLevyViewData();

    return () => (isMounted.current = false);
  }, [companyId, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <DataTable className="p-datatable-gridlines" value={itLevyData} style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      <Column field="credit" header="₦"></Column>
    </DataTable>
  );
};

export default ITLevyView;
