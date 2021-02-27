import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import { incomeTaxDelete, incomeTaxViewData } from "../../apis/IncomeTax";
import ViewModeDataTable from "../common/ViewModeDataTable";
import ViewLoader from "../common/ViewLoader";

const IncomeTaxView = ({ year, toast, showITLevy, isBringLossFoward }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [incomeTaxData, setIncomeTaxData] = React.useState();

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
                  <p className="margin-0">
                    {item.canBolden ? <strong>{item.description}</strong> : item.description}
                  </p>
                  {item.canDelete && (
                    <i
                      className="pi pi-times-circle delete"
                      style={{ fontSize: 14, marginTop: 2 }}
                      onClick={async () => {
                        try {
                          setLoading(true);
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
                          utils.apiErrorHandling(error, toast);
                        } finally {
                          setLoading(false);
                        }
                      }}></i>
                  )}
                </div>
              ),
              columnOne: item.canBolden ? (
                <>
                  {item.canUnderlineUpColumn1 && <div className="top-line"></div>}
                  <strong>{item.columnOne}</strong>
                  {item.canUnderlineDownColumn1 && <div className="bottom-line"></div>}
                </>
              ) : (
                <>
                  {item.canUnderlineUpColumn1 && <div className="top-line"></div>}
                  {item.columnOne}
                  {item.canUnderlineDownColumn1 && <div className="bottom-line"></div>}
                </>
              ),
              columnTwo: item.canBolden ? (
                <>
                  {item.canUnderlineUpColumn2 && <div className="top-line"></div>}
                  <strong>{item.columnTwo}</strong>
                  {item.canUnderlineDownColumn2 && <div className="bottom-line"></div>}
                </>
              ) : (
                <>
                  {item.canUnderlineUpColumn2 && <div className="top-line"></div>}
                  {item.columnTwo}
                  {item.canUnderlineDownColumn2 && <div className="bottom-line"></div>}
                </>
              )
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
    fetchIncomeTaxViewData();

    return () => (isMounted.current = false);
  }, [companyId, isBringLossFoward, showITLevy, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  return (
    <>
      {incomeTaxData && (
        <ViewModeDataTable value={incomeTaxData}>
          <Column field="description" header="Description"></Column>
          <Column field="columnOne" header="₦"></Column>
          <Column field="columnTwo" header="₦"></Column>
        </ViewModeDataTable>
      )}
      {loading && <ViewLoader />}
    </>
  );
};

export default IncomeTaxView;
