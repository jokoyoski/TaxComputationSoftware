
using Microsoft.AspNetCore.Http;

namespace TaxComputationAPI.Dtos
{
    public class UploadTrackTrialBalanceDto
    {
        public IFormFile File { get; set; }
        public int CompanyId { get; set; }
        public int YearId { get; set; }
    }
}