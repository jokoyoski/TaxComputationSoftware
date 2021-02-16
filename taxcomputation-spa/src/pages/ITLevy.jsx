import React from "react";
import Layout from "../components/layout";
import ITLevyView from "../components/it_levy/ITLevyView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam } from "react-resource-router";
import { Toast } from "primereact/toast";

const ITLevy = () => {
  const title = constants.modules.itLevy;
  const [toast, setToast] = React.useState(null);
  const [mode, setMode] = usePathParam("mode");
  const [year, setYear] = React.useState(utils.currentYear());
  const yearSelectItems = utils.getYears(year => ({
    label: year.toString(),
    value: year.toString()
  }));

  return (
    <Layout title={title}>
      <Main
        title={title}
        mode={mode}
        setMode={setMode}
        year={year}
        setYear={setYear}
        yearSelectItems={yearSelectItems}>
        <ViewMode title={title} year={year}>
          <ITLevyView year={year} toast={toast} />
        </ViewMode>
      </Main>
      <Toast baseZIndex={1000} ref={el => setToast(el)} />
    </Layout>
  );
};

export default ITLevy;
