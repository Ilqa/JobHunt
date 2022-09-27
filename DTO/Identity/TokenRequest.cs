using System.ComponentModel.DataAnnotations;

namespace JobHunt.DTO.Identity
{
    public class TokenRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}