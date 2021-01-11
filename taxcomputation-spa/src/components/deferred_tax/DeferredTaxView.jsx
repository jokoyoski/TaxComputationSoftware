import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import { deferredTaxViewData, deferredTaxDelete } from "../../apis/DeferredTax";
import utils from "../../utils";
import ViewModeDataTable from "../common/ViewModeDataTable";

const DeferredTaxView = ({ year, toast, isBringDeferredTaxFoward }) => {
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
        const data = await deferredTaxViewData({ companyId, year, isBringDeferredTaxFoward });
        if (isMounted.current) {
          setDeferredTaxData(
            data.map(item => ({
              ...item,
              description: (
                <div className="p-d-flex p-jc-between p-ai-center">
                  <p>{item.canBolden ? <strong>{item.description}</strong> : item.description}</p>
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
                          utils.apiErrorHandling(error, toast);
                        }
                      }}></i>
                  )}
                </div>
              ),
              columnOne: item.canBolden ? <strong>{item.columnOne}</strong> : item.columnOne,
              columnTwo: item.canBolden ? <strong>{item.columnTwo}</strong> : item.columnTwo
            }))
          );
        }
      } catch (error) {
        let errorString = utils.apiErrorHandling(error, toast);
        setError(errorString);
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchDeferredTaxViewData();

    return () => (isMounted.current = false);
  }, [companyId, toast, year, isBringDeferredTaxFoward]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <ViewModeDataTable value={deferredTaxData}>
      <Column field="description" header="Description"></Column>
      <Column field="columnOne" header="₦"></Column>
      <Column field="columnTwo" header="₦"></Column>
    </ViewModeDataTable>
  );
};

export default DeferredTaxView;
