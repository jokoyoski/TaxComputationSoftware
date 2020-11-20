import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import Loader from "../common/Loader";
import { capitalAllowanceViewData } from "../../apis/CapitalAllowance";
import utils from "../../utils";

const CapitalAllowanceView = ({ assetId }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [capitalAllowanceData, setCapitalAllowanceData] = React.useState([]);

  React.useEffect(() => {
    isMounted.current = true;
    const fetchCapitalAllowanceViewData = async () => {
      if (!assetId) return;

      try {
        setError(null);
        setLoading(true);
        const {
          capitalAllowances,
          openingResidualTotal,
          additionTotal,
          disposalTotal,
          initialTotal,
          annualTotal,
          totalTotal,
          closingResidueTotal
        } = await capitalAllowanceViewData({ companyId, assetId });
        if (isMounted.current)
          setCapitalAllowanceData(() => {
            const newState = capitalAllowances
              .map(capitalAllowance => ({
                ...capitalAllowance,
                taxYear: <strong>{capitalAllowance.taxYear}</strong>,
                openingResidue: utils.currencyFormatter(capitalAllowance.openingResidue),
                addition: utils.currencyFormatter(capitalAllowance.addition),
                disposal: utils.currencyFormatter(capitalAllowance.disposal),
                initial: utils.currencyFormatter(capitalAllowance.initial),
                annual: utils.currencyFormatter(capitalAllowance.annual),
                total: utils.currencyFormatter(capitalAllowance.total),
                closingResidue: utils.currencyFormatter(capitalAllowance.closingResidue)
              }))
              .concat([
                {
                  taxYear: "",
                  openingResidue: "",
                  addition: "",
                  disposal: "",
                  initial: "",
                  annual: "",
                  total: "",
                  closingResidue: ""
                },
                {
                  openingResidue: <strong>{utils.currencyFormatter(openingResidualTotal)}</strong>,
                  addition: <strong>{utils.currencyFormatter(additionTotal)}</strong>,
                  disposal: <strong>{utils.currencyFormatter(disposalTotal)}</strong>,
                  initial: <strong>{utils.currencyFormatter(initialTotal)}</strong>,
                  annual: <strong>{utils.currencyFormatter(annualTotal)}</strong>,
                  total: <strong>{utils.currencyFormatter(totalTotal)}</strong>,
                  closingResidue: <strong>{utils.currencyFormatter(closingResidueTotal)}</strong>
                }
              ]);

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
    fetchCapitalAllowanceViewData();

    return () => (isMounted.current = false);
  }, [companyId, assetId]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (loading) return <Loader />;

  if (capitalAllowanceData.length === 0)
    return (
      <p style={{ color: "#f00" }}>Currently, no data for the selected year for this company</p>
    );

  return (
    <DataTable value={capitalAllowanceData} style={{ marginTop: 40 }}>
      <Column field="taxYear" header="Tax Year"></Column>
      <Column field="openingResidue" header="Opening Residue"></Column>
      <Column field="addition" header="Addition"></Column>
      <Column field="disposal" header="Disposal"></Column>
      <Column field="initial" header="Initial"></Column>
      <Column field="annual" header="Annual"></Column>
      <Column field="total" header="Total"></Column>
      <Column field="closingResidue" header="Closing Residue"></Column>
      <Column field="yearsToGo" header="Yr to go"></Column>
    </DataTable>
  );
};

export default CapitalAllowanceView;
