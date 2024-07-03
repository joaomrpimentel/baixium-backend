using Microsoft.AspNetCore.Identity;
namespace MinimalAPI.Models
{
    public class User : IdentityUser
    {

        public string? Name { get; set; }
        public string? AvatarURL { get; set; } = "https://i.ibb.co/G2S34kJ/Captura-de-tela-2024-06-26-002307.png";
        public string? Description { get; set; }
    }
}