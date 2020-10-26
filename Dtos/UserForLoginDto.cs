using System.ComponentModel.DataAnnotations;

namespace TaxComputationAPI.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}