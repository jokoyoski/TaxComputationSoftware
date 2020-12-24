import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import { deferredTaxViewData, deferredTaxDelete } from "../../apis/DeferredTax";
import utils from "../../utils";

const DeferredTaxView = ({ year, toast }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [deferredTaxData, setDeferredTaxData] = React.useState([]);

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;
    const fetchDeferredTaxViewData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await deferredTaxViewData({ companyId, year });
        if (isMounted.current) {
          setDeferredTaxData(
            data.map(item => ({
              ...item,
              description: (
                <div className="p-d-flex p-jc-between p-ai-center">
                  <p>{item.description}</p>
                  {item.canDelete && (
                    <i
                      className="pi pi-times-circle delete"
                      style={{ fontSize: 14, marginTop: 2 }}
                      onClick={async () => {
                        try {
                          const data = await deferredTaxDelete(item.id);
                          if (data) {
                            toast.show(
                              utils.toastCallback({
                                severity: "success",
                                detail: data
                              })
                            );
                            fetchDeferredTaxViewData();
                          }
                        } catch (error) {
                          console.log(error);
                        }
                      }}></i>
                  )}
                </div>
              )
            }))
          );
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
    fetchDeferredTaxViewData();

    return () => (isMounted.current = false);
  }, [companyId, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <DataTable className="p-datatable-gridlines" value={deferredTaxData} style={{ marginTop: 40 }}>
      <Column field="description" header="Description"></Column>
      <Column field="columnOne" header="₦"></Column>
      <Column field="columnTwo" header="₦"></Column>
    </DataTable>
  );
};

export default DeferredTaxView;
