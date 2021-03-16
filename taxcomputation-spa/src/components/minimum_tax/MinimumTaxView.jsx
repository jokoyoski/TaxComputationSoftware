import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import utils from "../../utils";
import { minimumTaxViewData, minimumTaxOldViewData } from "../../apis/MinimumTax";
import ViewModeDataTable from "../common/ViewModeDataTable";
import ViewLoader from "../common/ViewLoader";
import constants from "../../constants";

const MinimumTaxView = ({
  year,
  toast,
  percentageTurnOver,
  setPercentageTurnOver,
  setPercentageTurnOverValue
}) => {
  const isMounted = React.useRef(true);
  const [{ companyId, minimumTaxTypeId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [minimumTaxData, setMinimumTaxData] = React.useState();

  React.useEffect(() => {
    isMounted.current = true;

    return () => (isMounted.current = false);
  }, []);

  React.useEffect(() => {
    if (!percentageTurnOver.value) {
      setMinimumTaxData(null);
      setPercentageTurnOverValue(undefined);
    }
  }, [percentageTurnOver.value, setPercentageTurnOverValue]);

  React.useEffect(() => {
    if (!companyId) return;

    if (minimumTaxTypeId === constants.minimumTaxType.old) {
      const fetchMinimumTaxOldViewData = async () => {
        try {
          setError(null);
          setLoading(true);
          const data = await minimumTaxOldViewData({
            companyId,
            year
          });
          if (isMounted.current) {
            console.log(data);
            setMinimumTaxData(
              data.values.map(item => ({
                ...item,
                value1: utils.currencyFormatter(item.value1),
                value2: utils.currencyFormatter(item.value2)
              }))
            );
          }
        } catch (error) {
          let errorString = utils.apiErrorHandling(error, toast);
          setError(errorString);
        } finally {
          if (isMounted.current) {
            setLoading(false);
          }
        }
      };
      fetchMinimumTaxOldViewData();
    } else {
      const fetchMinimumTaxViewData = async () => {
        if (!percentageTurnOver.canQuery) return;
        else if (isNaN(percentageTurnOver.value)) {
          toast.show(
            utils.toastCallback({
              severity: "error",
              detail: "Percentage Turn Over is not a number"
            })
          );
        }

        try {
          setError(null);
          setLoading(true);
          setPercentageTurnOver(state => ({ ...state, canQuery: null }));
          const data = await minimumTaxViewData({
            companyId,
            year,
            percentageTurnOver: Number(percentageTurnOver.value)
          });
          if (isMounted.current) {
            setMinimumTaxData(() => {
              let newState = [];
              return newState.concat([
                {
                  category: <strong>Minimum Tax Payable</strong>,
                  credit: utils.currencyFormatter(data.turnOver)
                },
                {
                  category: "Dividend Income",
                  credit: data.dividend ? utils.currencyFormatter(data.dividend) : null
                },
                {
                  category: `${percentageTurnOver.value}% OF TURNOVER`,
                  credit: utils.currencyFormatter(data.fivePercentTurnOver)
                }
              ]);
            });
          }
        } catch (error) {
          let errorString = utils.apiErrorHandling(error, toast);
          setError(errorString);
        } finally {
          if (isMounted.current) {
            setLoading(false);
            setPercentageTurnOver(state => ({ ...state, canQuery: false }));
          }
        }
      };
      fetchMinimumTaxViewData();
    }
  }, [companyId, minimumTaxTypeId, percentageTurnOver, setPercentageTurnOver, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  return (
    <>
      {minimumTaxData && minimumTaxTypeId === constants.minimumTaxType.old && (
        <ViewModeDataTable value={minimumTaxData}>
          <Column field="name" header=""></Column>
          <Column field="value1" header="₦"></Column>
          <Column field="value2" header="₦"></Column>
        </ViewModeDataTable>
      )}
      {minimumTaxData && minimumTaxTypeId === constants.minimumTaxType.new && (
        <ViewModeDataTable value={minimumTaxData}>
          <Column field="category" header=""></Column>
          <Column field="credit" header="₦"></Column>
        </ViewModeDataTable>
      )}
      {loading && <ViewLoader />}
    </>
  );
};

export default MinimumTaxView;
