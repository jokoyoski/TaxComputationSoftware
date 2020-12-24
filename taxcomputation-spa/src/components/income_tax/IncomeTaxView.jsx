import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import utils from "../../utils";
import { incomeTaxDelete, incomeTaxViewData } from "../../apis/IncomeTax";

const IncomeTaxView = ({ year, toast, showITLevy }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [incomeTaxData, setIncomeTaxData] = React.useState([]);

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;
    const fetchIncomeTaxViewData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await incomeTaxViewData({ companyId, year, isItLevyView: showITLevy });
        if (isMounted.current) {
          setIncomeTaxData(
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
                          const data = await incomeTaxDelete(item.id);
                          if (data) {
                            toast.show(
                              utils.toastCallback({
                                severity: "success",
                                detail: data
                              })
                            );
                            fetchIncomeTaxViewData();
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
    fetchIncomeTaxViewData();

    return () => (isMounted.current = false);
  }, [companyId, showITLevy, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <DataTable className="p-datatable-gridlines" value={incomeTaxData} style={{ marginTop: 40 }}>
      <Column field="description" header="Description"></Column>
      <Column field="columnOne" header="₦"></Column>
      <Column field="columnTwo" header="₦"></Column>
    </DataTable>
  );
};

export default IncomeTaxView;
