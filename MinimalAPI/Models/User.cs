using Microsoft.AspNetCore.Identity;
namespace MinimalAPI.Models
{
    public class User : IdentityUser
    {

        public string? Name { get; set; }
        public string? AvatarURL { get; set; }
        public string? Description { get; set; }
    }
}