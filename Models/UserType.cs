using Microsoft.AspNetCore.Identity;

namespace MovieReviews.Models
{
    public class UserType: IdentityRole<string>
    {
        public string ACLIds { get; set; }  
    }
}
