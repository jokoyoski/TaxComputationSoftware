import React from "react";
import utils from "../../utils";

const useFetchCompanyDetails = (companyId = null) => {
  const [loading, setLoading] = React.useState(false);
  const [error, setError] = React.useState(null);
  const [companyDetails, setCompanyDetails] = React.useState(null);

  const fetchCompany = React.useCallback(async () => {
    if (companyId) {
      await utils.fetchCompanyCallback(setLoading, setError, companyId, setCompanyDetails);
    }
  }, [companyId]);

  React.useEffect(() => {
    fetchCompany();
  }, [fetchCompany]);

  return { companyDetails, loading, error, fetchCompany };
};

export default useFetchCompanyDetails;
