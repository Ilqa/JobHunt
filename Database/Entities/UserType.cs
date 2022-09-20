using Microsoft.AspNetCore.Identity;

namespace MovieReviews.Entities
{
    public class UserType : IdentityRole<int>
    {
        public string ACLIds { get; set; }
    }
}
