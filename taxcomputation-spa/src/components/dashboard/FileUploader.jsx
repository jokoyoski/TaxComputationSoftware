import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";
import { Dropdown } from "primereact/dropdown";
import utils from "../../utils";
import { uploadTrialBalance } from "../../apis/TrialBalance";
import { useResources } from "../../store/ResourcesStore";

const FileUploader = ({ company: { companyId }, toast, setRefreshTrialBalanceTable }) => {
  const [file, setFile] = React.useState();
  const [year, setYear] = React.useState();
  const [loading, setLoading] = React.useState(false);
  const [{ financialYears }] = useResources();

  const onUpload = async () => {
    if (loading) return;

    if (!file && !year) {
      toast.show(
        utils.toastCallback({ severity: "error", detail: "Add TB File and Select Tax Year" })
      );
      return;
    } else if (!file) {
      toast.show(utils.toastCallback({ severity: "error", detail: "Add TB File" }));
      return;
    } else if (!year) {
      toast.show(utils.toastCallback({ severity: "error", detail: "Select Tax Year" }));
      return;
    }

    setLoading(true);

    try {
      const response = await uploadTrialBalance({ file, companyId, year });
      if (response.status === 200) {
        setYear(null);
        setFile(null);
        setRefreshTrialBalanceTable(true);
        toast.show(utils.toastCallback({ severity: "success", detail: response.data }));
      }
    } catch (error) {
      utils.apiErrorHandling(error, toast);
    } finally {
      setLoading(false);
    }
  };

  return (
    <Card
      header={
        <div className="p-d-flex p-jc-center p-flex-column" style={{ width: "100%" }}>
          <div className="p-d-flex p-ai-center p-jc-between" style={{ padding: "0px 20px" }}>
            <p style={{ fontSize: 18, fontWeight: 600 }}>Upload File</p>
            <div>
              <Dropdown
                style={{ marginRight: 20, width: 120 }}
                value={year}
                options={financialYears}
                onChange={e => {
                  setYear(e.value);
                }}
                placeholder="Tax Year"
              />
              <Button
                style={{ width: 120 }}
                label={!loading ? "Upload" : null}
                icon={loading ? "pi pi-spin pi-spinner" : "pi pi-upload"}
                onClick={onUpload}
              />
            </div>
          </div>
          <div className="divider"></div>
        </div>
      }
      style={{ width: "100%", marginBottom: 20 }}>
      <div className="p-d-flex">
        <div className="p-d-flex p-ai-center p-jc-center file-uploader-container">
          <p className="accent-color" style={{ fontSize: 20 }}>
            {file && file.item(0).name
              ? `"${file.item(0).name}" ready for upload`
              : "Click or Drag and drop Trial Balance file here to upload."}
          </p>
          <input
            type="file"
            accept=".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"
            style={{
              position: "absolute",
              width: "100%",
              height: "100%",
              opacity: 0
            }}
            onChange={e => setFile(e.target.files)}
          />
        </div>
      </div>
    </Card>
  );
};

export default FileUploader;
