using Microsoft.AspNetCore.Identity;

namespace JobHunt.Database.Entities
{
    public class UserType : IdentityRole<int>
    {
        public string ACLIds { get; set; }
    }
}
