import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import { capitalAllowanceSummaryData } from "../../apis/CapitalAllowance";

const CapitalAllowanceSummary = () => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [capitalAllowanceSummary, setCapitalAllowanceSummary] = React.useState([]);

  React.useEffect(() => {
    if (!companyId) return;

    isMounted.current = true;
    const fetchCapitalAllowanceSummaryData = async () => {
      try {
        setError(null);
        setLoading(true);
        const data = await capitalAllowanceSummaryData({ companyId });
        console.log(11, data);
        if (isMounted.current)
          setCapitalAllowanceSummary(() => {
            let newState = data.map((item, index) => {
              if (index < data.length - 1)
                return { ...item, description: <strong>{item.description}</strong> };
              else
                return {
                  ...item,
                  description: <strong>{item.description}</strong>,
                  openingResidue: <strong>{item.openingResidue}</strong>,
                  addition: <strong>{item.addition}</strong>,
                  disposalOrTransfer: <strong>{item.disposalOrTransfer}</strong>,
                  initial: <strong>{item.initial}</strong>,
                  annual: <strong>{item.annual}</strong>,
                  total: <strong>{item.total}</strong>,
                  closingResidue: <strong>{item.closingResidue}</strong>
                };
            });
            newState.splice(newState.length - 1, 0, {});
            return newState;
          });
      } catch (error) {
        if (isMounted.current) {
          if (error.response) setError(error.response.data.errors[0]);
          else setError(error.message);
        }
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchCapitalAllowanceSummaryData();

    return () => (isMounted.current = false);
  }, [companyId]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  if (capitalAllowanceSummary.length === 0)
    return (
      <p style={{ color: "#f00" }}>Currently, no data for the selected year for this company</p>
    );

  return (
    <DataTable
      className="p-datatable-gridlines"
      value={capitalAllowanceSummary}
      style={{ marginTop: 40, width: 1200 }}
      scrollable>
      <Column field="description" header="Description" headerStyle={{ width: "10em" }}></Column>
      <Column
        field="openingResidue"
        header="Opening Residue"
        headerStyle={{ width: "10em" }}></Column>
      <Column field="addition" header="Addition" headerStyle={{ width: "10em" }}></Column>
      <Column
        field="disposalOrTransfer"
        header="Disposal/Transfer"
        headerStyle={{ width: "10em" }}></Column>
      <Column field="initial" header="Initial" headerStyle={{ width: "10em" }}></Column>
      <Column field="annual" header="Annual" headerStyle={{ width: "10em" }}></Column>
      <Column field="total" header="Total" headerStyle={{ width: "10em" }}></Column>
      <Column
        field="closingResidue"
        header="Closing Residue"
        headerStyle={{ width: "10em" }}></Column>
    </DataTable>
  );
};

export default CapitalAllowanceSummary;
