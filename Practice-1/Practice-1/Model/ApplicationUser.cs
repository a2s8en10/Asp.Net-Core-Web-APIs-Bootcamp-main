using Microsoft.AspNetCore.Identity;

namespace Practice_1.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
