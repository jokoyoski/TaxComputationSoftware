import React from "react";
import { Column } from "primereact/column";
import { useCompany } from "../../store/CompanyStore";
import { capitalAllowanceDelete, capitalAllowanceViewData } from "../../apis/CapitalAllowance";
import utils from "../../utils";
import ViewModeDataTable from "../common/ViewModeDataTable";
import ViewLoader from "../common/ViewLoader";

const CapitalAllowanceView = ({ assetId, toast }) => {
  const isMounted = React.useRef(false);
  const [{ companyId }] = useCompany();
  const [loading, setLoading] = React.useState();
  const [error, setError] = React.useState();
  const [capitalAllowanceData, setCapitalAllowanceData] = React.useState();

  React.useEffect(() => {
    if (!companyId) return;

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
              ?.map(capitalAllowance => ({
                ...capitalAllowance,
                taxYear: (
                  <div className="p-d-flex p-jc-between p-ai-center">
                    <strong>{capitalAllowance.taxYear}</strong>
                    <i
                      className="pi pi-times-circle delete"
                      style={{ fontSize: 14, marginTop: 2 }}
                      onClick={async () => {
                        try {
                          setLoading(true);
                          const data = await capitalAllowanceDelete(capitalAllowance.id);
                          if (data) {
                            toast.show(
                              utils.toastCallback({
                                severity: "success",
                                detail: data
                              })
                            );
                            fetchCapitalAllowanceViewData();
                          }
                        } catch (error) {
                          utils.apiErrorHandling(error, toast);
                        } finally {
                          setLoading(false);
                        }
                      }}></i>
                  </div>
                )
              }))
              .concat([
                {},
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
        let errorString = utils.apiErrorHandling(error, toast);
        setError(errorString);
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    fetchCapitalAllowanceViewData();

    return () => (isMounted.current = false);
  }, [companyId, assetId, toast]);

  if (error) return <p style={{ color: "#f00" }}>{error}</p>;

  if (capitalAllowanceData?.length === 0)
    return (
      <p style={{ color: "#f00" }}>Currently, no data for the selected year for this company</p>
    );

  return (
    <>
      {capitalAllowanceData && (
        <ViewModeDataTable value={capitalAllowanceData} width={1200} scrollable>
          <Column field="taxYear" header="Tax Year" headerStyle={{ width: "8em" }}></Column>
          <Column
            field="numberOfYearsAvailable"
            header="Year(s) Available"
            headerStyle={{ width: "6em" }}></Column>
          <Column
            field="openingResidue"
            header="Opening Residue"
            headerStyle={{ width: "10em" }}></Column>
          <Column field="addition" header="Addition" headerStyle={{ width: "10em" }}></Column>
          <Column field="disposal" header="Disposal" headerStyle={{ width: "10em" }}></Column>
          <Column field="initial" header="Initial" headerStyle={{ width: "10em" }}></Column>
          <Column field="annual" header="Annual" headerStyle={{ width: "10em" }}></Column>
          <Column field="total" header="Total" headerStyle={{ width: "10em" }}></Column>
          <Column
            field="closingResidue"
            header="Closing Residue"
            headerStyle={{ width: "10em" }}></Column>
          <Column field="yearsToGo" header="Yr to go" headerStyle={{ width: "6em" }}></Column>
        </ViewModeDataTable>
      )}
      {loading && <ViewLoader />}
    </>
  );
};

export default CapitalAllowanceView;
