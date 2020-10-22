using System.ComponentModel.DataAnnotations;

namespace TaxComputationSoftware.Dtos
{
    public class ChangePasswordDto
    {
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage="You must specify password between 6 and 15 characters")]
        public string CurrentPassword { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage="You must specify password between 6 and 15 characters")]
        public string NewPassword { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage="You must specify password between 6 and 15 characters")]
        [Compare("NewPassword", ErrorMessage = "The Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}