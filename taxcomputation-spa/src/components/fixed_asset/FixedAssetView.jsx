import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { fixedAssetViewData } from "../../apis/FixedAsset";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import Loader from "../common/Loader";

const FixedAssetView = ({ year }) => {
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
      category: <strong>As at 31/12/{year - 1}</strong>,
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
      category: <strong>As at 31/12/{year - 1}</strong>,
      key: "depreciationClosing"
    },
    {
      category: null
    },
    {
      category: <strong>Net Book Value</strong>
    },
    {
      category: <strong>As at 31/12/{year - 1}</strong>,
      key: "netValue"
    }
  ]);

  React.useEffect(() => {
    isMounted.current = true;
    const fetchFixedAssetViewData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await fixedAssetViewData({ companyId, year });
        if (isMounted.current) {
          setFixedAssetApiData(data.fixedAssetData);
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
                    s[d.fixedAssetName] = <strong>{data.netBookValue[index].value}</strong>;
                    s.total = (
                      <strong>
                        {utils.currencyFormatter(
                          data.netBookValue.reduce(
                            (acc, cur) => acc + Number(cur.value.slice(1).replace(/,/g, "")),
                            0
                          )
                        )}
                      </strong>
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
        if (isMounted.current) {
          if (error.response) setError(error.response.data.errors[0]);
          else setError(error.message);
        }
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchFixedAssetViewData();

    return () => (isMounted.current = false);
  }, [companyId, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <DataTable className="p-datatable-gridlines" value={fixedAssetData} style={{ marginTop: 40 }}>
      <Column field="category" header=""></Column>
      {fixedAssetApiData &&
        fixedAssetApiData.map(d => (
          <Column key={d.fixedAssetName} field={d.fixedAssetName} header={`${d.fixedAssetName}`} />
        ))}
      <Column field="total" header="Total"></Column>
    </DataTable>
  );
};

export default FixedAssetView;
