using Microsoft.AspNetCore.Identity;

namespace CustomerRelationshipManagementSystem.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string City { get; set; }
    }
}
