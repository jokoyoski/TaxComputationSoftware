
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TaxComputationAPI.Dtos
{
    public class UploadTrackTrialBalanceDto
    {
       [Required]
        public IFormFile File { get; set; }
        public int CompanyId { get; set; }
        public int YearId { get; set; }
    }
}