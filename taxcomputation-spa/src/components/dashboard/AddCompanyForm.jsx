import React from "react";
import { Dialog } from "primereact/dialog";
import { InputText } from "primereact/inputtext";
import { Button } from "primereact/button";

const AddCompanyForm = ({ showAddCompany, setShowAddCompany }) => {
  const [companyName, setCompanyName] = React.useState();
  const [companyAddress, setCompanyAddress] = React.useState();

  return (
    <Dialog
      header="Add Company"
      visible={showAddCompany}
      style={{ width: 400 }}
      focusOnShow={false}
      onHide={() => setShowAddCompany(false)}>
      <form>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 20 }}>
          <label htmlhtmlFor="companyNameInput" style={{ marginBottom: 10 }}>
            Company Name
          </label>
          <InputText
            id="companyNameInput"
            required
            value={companyName}
            onChange={e => setCompanyName(e.target.value)}
          />
        </div>
        <div className="p-d-flex p-flex-column" style={{ marginBottom: 20 }}>
          <label htmlhtmlFor="companyAddressInput" style={{ marginBottom: 10 }}>
            Company Address
          </label>
          <InputText
            id="companyAddressInput"
            required
            value={companyAddress}
            onChange={e => setCompanyAddress(e.target.value)}
          />
        </div>
        <Button label="Submit" type="submit" style={{ width: "100%", marginTop: 10 }} />
      </form>
    </Dialog>
  );
};

export default AddCompanyForm;
