import React from "react";
import ViewMode from "../components/common/ViewMode";
import Layout from "../components/layout";
import Main from "../components/layout/Main";
import constants from "../constants";
import utils from "../utils";
import { usePathParam } from "react-resource-router";
import FixedAssetMapping from "../components/fixed_asset/FixedAssetMapping";

const FixedAsset = () => {
  const title = constants.modules.fixedAsset;
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
        {
          {
            mapping: (
              <FixedAssetMapping year={year} setYear={setYear} yearSelectItems={yearSelectItems} />
            ),
            view: <ViewMode title={title}></ViewMode>
          }[mode]
        }
      </Main>
    </Layout>
  );
};

export default FixedAsset;
