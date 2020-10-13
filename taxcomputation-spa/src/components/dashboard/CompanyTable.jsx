import React from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Card } from "primereact/card";
import { Button } from "primereact/button";

const CompanyTable = ({ setShowAddCompany }) => {
  const actionButtons = (
    <div className="p-d-flex">
      <Button label="View" className="p-button-text" />
      <Button label="Edit" className="p-button-text" />
      <Button label="Delete" className="p-button-text" />
    </div>
  );

  const [allCompanies] = React.useState([
    {
      companyName: "Interswitch",
      address: "1648C Oko Awo St, Victoria Island, Lagos",
      numberOfUsers: "10 users",
      action: actionButtons
    },
    {
      companyName: "Interswitch",
      address: "1648C Oko Awo St, Victoria Island, Lagos",
      numberOfUsers: "10 users",
      action: actionButtons
    },
    {
      companyName: "Interswitch",
      address: "1648C Oko Awo St, Victoria Island, Lagos",
      numberOfUsers: "10 users",
      action: actionButtons
    },
    {
      companyName: "Interswitch",
      address: "1648C Oko Awo St, Victoria Island, Lagos",
      numberOfUsers: "10 users",
      action: actionButtons
    },
    {
      companyName: "Interswitch",
      address: "1648C Oko Awo St, Victoria Island, Lagos",
      numberOfUsers: "10 users",
      action: actionButtons
    }
  ]);

  return (
    <Card style={{ width: "100%" }}>
      <DataTable
        value={allCompanies}
        className="p-datatable-gridlines"
        header={
          <Button
            label="Add Company"
            icon="pi pi-plus"
            className="p-button-outlined"
            onClick={() => setShowAddCompany(true)}
          />
        }>
        <Column field="companyName" header="Company Name"></Column>
        <Column field="address" header="Address"></Column>
        <Column field="numberOfUsers" header="Number of users"></Column>
        <Column field="action" header="Action"></Column>
      </DataTable>
    </Card>
  );
};

export default CompanyTable;
