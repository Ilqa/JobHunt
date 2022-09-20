using System.ComponentModel.DataAnnotations;

namespace MovieReviews.Models
{
    public class TokenRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}