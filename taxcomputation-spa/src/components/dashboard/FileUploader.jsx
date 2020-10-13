import React from "react";
import { Card } from "primereact/card";
import { Button } from "primereact/button";

const FileUploader = () => {
  return (
    <Card
      header={
        <div className="p-d-flex p-jc-center p-flex-column" style={{ width: "100%" }}>
          <div className="p-d-flex p-ai-center p-jc-between" style={{ padding: "0px 20px" }}>
            <p style={{ fontSize: 18, fontWeight: 600 }}>Upload File</p>
            <Button label="Upload" icon="pi pi-upload" />
          </div>
          <div className="divider"></div>
        </div>
      }
      style={{ width: "100%", marginBottom: 20 }}>
      <div className="p-d-flex">
        <div
          className="p-d-flex p-ai-center p-jc-center"
          style={{ background: "#f5f6f8", width: "100%", height: 100, position: "relative" }}>
          <p className="accent-color" style={{ fontSize: 20 }}>
            Click or Drag and drop Trial Balance file here to upload.
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
          />
        </div>
      </div>
    </Card>
  );
};

export default FileUploader;
