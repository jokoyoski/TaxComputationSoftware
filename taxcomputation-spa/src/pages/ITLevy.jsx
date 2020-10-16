import React from "react";
import Layout from "../components/layout";
import ITLevyView from "../components/it_levy/ITLevyView";
import ViewMode from "../components/common/ViewMode";
import constants from "../constants";
import utils from "../utils";
import Main from "../components/layout/Main";
import { usePathParam } from "react-resource-router";

const ITLevy = () => {
  const title = constants.modules.itLevy;
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
        <ViewMode title={title}>
          <ITLevyView />
        </ViewMode>
      </Main>
    </Layout>
  );
};

export default ITLevy;
