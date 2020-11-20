import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Card } from "primereact/card";
import { Dropdown } from "primereact/dropdown";
import utils from "../../utils";
import { getTrialBalance } from "../../apis/TrialBalance";

const TrialBalanceTable = ({
  company: { companyId },
  refreshTrialBalanceTable,
  setRefreshTrialBalanceTable
}) => {
  const isMounted = React.useRef(false);
  const [year, setYear] = React.useState(utils.currentYear());
  const [yearSelectItems] = React.useState(utils.getYears());
  const [tbData, setTbData] = React.useState([]);
  const [loading, setLoading] = React.useState(false);

  React.useEffect(() => {
    isMounted.current = true;
    const fetchTrialBalance = async () => {
      setLoading(true);
      try {
        const data = await getTrialBalance({ companyId, year });
        if (isMounted.current) {
          setTbData(
            data
              ? data.map(d => {
                  if (d.accountId === "" && d.item === "" && d.debit === 0 && d.credit === 0) {
                    return { ...d, debit: "", credit: "" };
                  } else {
                    return {
                      ...d,
                      debitAmt: utils.currencyFormatter(d.debit),
                      creditAmt: utils.currencyFormatter(d.credit)
                    };
                  }
                })
              : []
          );
        }
      } catch (error) {
        console.log(error);
      } finally {
        if (isMounted.current) setLoading(false);
      }
    };
    if (refreshTrialBalanceTable) {
      fetchTrialBalance();
      if (isMounted.current) setRefreshTrialBalanceTable(false);
    }

    return () => (isMounted.current = false);
  }, [companyId, year, refreshTrialBalanceTable, setRefreshTrialBalanceTable]);

  return (
    <Card style={{ width: "100%" }}>
      <DataTable
        value={tbData}
        paginator={!loading && tbData.length !== 0}
        rows={10}
        rowsPerPageOptions={[10, 20, 50, 100]}
        header={
          <div className="p-d-flex p-ai-center p-jc-between">
            <p style={{ fontSize: 18, fontWeight: 600 }}>Trial Balance</p>
            <Dropdown
              style={{ width: 110 }}
              value={year}
              options={yearSelectItems}
              onChange={e => {
                setYear(e.value);
                setRefreshTrialBalanceTable(true);
              }}
              placeholder="TB Year"
            />
          </div>
        }
        footer={
          loading || tbData.length === 0 ? (
            <>
              <div className="p-d-flex p-ai-center p-jc-center">
                {loading && <i className="pi pi-spin pi-spinner" style={{ fontSize: "2em" }}></i>}
                {!loading && tbData.length === 0 && <p>No Trial Balance data for selected year</p>}
              </div>
            </>
          ) : null
        }>
        <Column field="accountId" header="Account ID"></Column>
        <Column field="item" header="Account Description"></Column>
        <Column field="debitAmt" header="Debit Amt"></Column>
        <Column field="creditAmt" header="Credit Amt"></Column>
      </DataTable>
    </Card>
  );
};

export default TrialBalanceTable;
