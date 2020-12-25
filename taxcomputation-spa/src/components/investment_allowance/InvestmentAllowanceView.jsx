import React from "react";
import { Column } from "primereact/column";
import Loader from "../common/Loader";
import { useCompany } from "../../store/CompanyStore";
import {
  investmentAllowanceDelete,
  investmentAllowanceViewData
} from "../../apis/InvestmentAllowance";
import utils from "../../utils";
import ViewModeDataTable from "../common/ViewModeDataTable";

const InvestmentAllowanceView = ({ year, toast }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [investmentAllowanceData, setInvestmentAllowanceData] = React.useState([]);

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;
    const fetchInvestmentAllowanceViewData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await investmentAllowanceViewData({ companyId, year });
        if (isMounted.current) {
          setInvestmentAllowanceData(
            data.investment.investments
              .map(item => ({
                ...item,
                name: (
                  <div className="p-d-flex p-jc-between p-ai-center">
                    <p>{item.name}</p>
                    <i
                      className="pi pi-times-circle delete"
                      style={{ fontSize: 14, marginTop: 2 }}
                      onClick={async () => {
                        try {
                          const data = await investmentAllowanceDelete(item.id);
                          if (data) {
                            toast.show(
                              utils.toastCallback({
                                severity: "success",
                                detail: data
                              })
                            );
                            fetchInvestmentAllowanceViewData();
                          }
                        } catch (error) {
                          console.log(error);
                        }
                      }}></i>
                  </div>
                )
              }))
              .concat([
                {
                  name: "Investment Allowance @ 10%",
                  amount: data.investment.investmentAllowanceatTenPercent
                }
              ])
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
    fetchInvestmentAllowanceViewData();

    return () => (isMounted.current = false);
  }, [companyId, toast, year]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  return (
    <ViewModeDataTable value={investmentAllowanceData}>
      <Column field="name" header="Additions to:"></Column>
      <Column field="amount" header="Amount"></Column>
    </ViewModeDataTable>
  );
};

export default InvestmentAllowanceView;
