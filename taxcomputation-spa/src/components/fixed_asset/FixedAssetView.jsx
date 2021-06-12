import React from "react";
import { Column } from "primereact/column";
import { fixedAssetDelete, fixedAssetViewData } from "../../apis/FixedAsset";
import { useCompany } from "../../store/CompanyStore";
import ViewModeDataTable from "../common/ViewModeDataTable";
import utils from "../../utils";
import ViewLoader from "../common/ViewLoader";

const FixedAssetView = ({ year, toast }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [fixedAssetApiData, setFixedAssetApiData] = React.useState();
  const [fixedAssetData, setFixedAssetData] = React.useState([
    {
      category: <strong>Cost</strong>
    },
    {
      category: "Opening Balance",
      key: "openingCost"
    },
    {
      category: "Additions",
      key: "costAddition"
    },
    {
      category: "Disposal",
      key: "costDisposal"
    },
    {
      category: "Transfer",
      key: "transferCost"
    },
    {
      category: <strong>Closing Balance</strong>,
      key: "costClosing"
    },
    {
      category: null
    },
    {
      category: <strong>Depreciation</strong>
    },
    {
      category: "Opening Balance",
      key: "openingDepreciation"
    },
    {
      category: "Charged for the year",
      key: "depreciationAddition"
    },
    {
      category: "Disposal",
      key: "depreciationDisposal"
    },
    {
      category: "Transfer",
      key: "transferDepreciation"
    },
    {
      category: <strong>Closing Balance</strong>,
      key: "depreciationClosing"
    },
    {
      category: null
    },
    {
      category: <strong>Net Book Value</strong>,
      key: "netValue"
    }
  ]);

  const fetchFixedAssetViewData = React.useCallback(async () => {
    try {
      setError(null);
      setLoading(true);
      const data = await fixedAssetViewData({ companyId, year });
      if (isMounted.current) {
        setFixedAssetApiData(data);
        setFixedAssetData(state => {
          const newState = Array.from(state);
          data.fixedAssetData.forEach((d, index) => {
            newState.forEach(s => {
              switch (s.key) {
                case "openingCost":
                  s[d.fixedAssetName] = d.openingCost;
                  s.total = data.total.openingCostTotal;
                  break;
                case "costAddition":
                  s[d.fixedAssetName] = d.costAddition;
                  s.total = data.total.additionCostTotal;
                  break;
                case "costDisposal":
                  s[d.fixedAssetName] = d.costDisposal;
                  s.total = data.total.disposalCostTotal;
                  break;
                case "transferCost":
                  s[d.fixedAssetName] = d.transferCost;
                  s.total = data.total.transferCostTotal;
                  break;
                case "costClosing":
                  s[d.fixedAssetName] = <strong>{d.costClosing}</strong>;
                  s.total = <strong>{data.total.closingCostTotal}</strong>;
                  break;
                case "openingDepreciation":
                  s[d.fixedAssetName] = d.openingDepreciation;
                  s.total = data.total.openingDepreciationTotal;
                  break;
                case "depreciationAddition":
                  s[d.fixedAssetName] = d.depreciationAddition;
                  s.total = data.total.additionDepreciationTotal;
                  break;
                case "depreciationDisposal":
                  s[d.fixedAssetName] = d.depreciationDisposal;
                  s.total = data.total.disposalDepreciationTotal;
                  break;
                case "transferDepreciation":
                  s[d.fixedAssetName] = d.transferDepreciation;
                  s.total = data.total.transferDepreciationTotal;
                  break;
                case "depreciationClosing":
                  s[d.fixedAssetName] = <strong>{d.depreciationClosing}</strong>;
                  s.total = <strong>{data.total.closingDepreciationTotal}</strong>;
                  break;
                case "netValue":
                  s[d.fixedAssetName] = <strong>{`₦${data.netBookValue[index].value}`}</strong>;
                  s.total = (
                    <strong>{`₦${data.netBookValue[data.netBookValue.length - 1].value}`}</strong>
                  );
                  break;
                default:
                  break;
              }
            });
          });
          return newState;
        });
      }
    } catch (error) {
      let errorString = utils.apiErrorHandling(error, toast);
      setError(errorString);
    } finally {
      if (isMounted.current) setLoading(false);
    }
  }, [companyId, toast, year]);

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;

    fetchFixedAssetViewData();

    return () => (isMounted.current = false);
  }, [companyId, fetchFixedAssetViewData]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  return (
    <>
      {fixedAssetApiData && (
        <ViewModeDataTable value={fixedAssetData} width={1200}>
          <Column field="category" header="" headerStyle={{ width: "10em" }}></Column>
          {fixedAssetApiData &&
            fixedAssetApiData.fixedAssetData.map(d => (
              <Column
                key={d.fixedAssetName}
                field={d.fixedAssetName}
                headerStyle={{ width: "10em" }}
                header={
                  <div className="p-d-flex p-jc-between p-ai-center">
                    <p>{`${d.fixedAssetName}`}</p>
                    {fixedAssetApiData.canDelete && (
                      <i
                        className="pi pi-times-circle delete"
                        style={{ fontSize: 14, marginTop: 2 }}
                        onClick={async () => {
                          try {
                            setLoading(true);
                            const data = await fixedAssetDelete(d.id);
                            if (data) {
                              toast.show(
                                utils.toastCallback({
                                  severity: "success",
                                  detail: data
                                })
                              );
                              fetchFixedAssetViewData();
                            }
                          } catch (error) {
                            utils.apiErrorHandling(error, toast);
                          } finally {
                            setLoading(false);
                          }
                        }}></i>
                    )}
                  </div>
                }
              />
            ))}
          <Column field="total" header="Total" headerStyle={{ width: "10em" }}></Column>
        </ViewModeDataTable>
      )}
      {loading && <ViewLoader />}
    </>
  );
};

export default FixedAssetView;
