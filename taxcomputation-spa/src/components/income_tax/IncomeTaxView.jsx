import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import utils from "../../utils";
import { incomeTaxDelete, incomeTaxViewData } from "../../apis/IncomeTax";
import ViewModeDataTable from "../common/ViewModeDataTable";

const IncomeTaxView = ({ year, toast, showITLevy, isBringLossFoward }) => {
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
        const data = await incomeTaxViewData({
          companyId,
          year,
          isItLevyView: showITLevy,
          isBringLossFoward
        });
        if (isMounted.current) {
          setIncomeTaxData(
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
              ),
              columnOne: item.canBolden ? <strong>{item.columnOne}</strong> : item.columnOne,
              columnTwo: item.canBolden ? <strong>{item.columnTwo}</strong> : item.columnTwo
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
  }, [companyId, isBringLossFoward, showITLevy, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <ViewModeDataTable value={incomeTaxData}>
      <Column field="description" header="Description"></Column>
      <Column field="columnOne" header="₦"></Column>
      <Column field="columnTwo" header="₦"></Column>
    </ViewModeDataTable>
  );
};

export default IncomeTaxView;
