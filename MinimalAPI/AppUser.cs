using Microsoft.AspNetCore.Identity;

namespace MinimalAPI
{
    public class AppUser : IdentityUser
    {
        public User User { get; set; }
    }

}