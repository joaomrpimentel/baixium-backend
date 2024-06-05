using Microsoft.AspNetCore.Identity;

namespace MinimalAPI
{
    public class User : AppUser
    {
        public DateTime createdAt = DateTime.Now;
        public string Nome { get; set; } = "Unknown";
        public Boolean isAdmin { get; set; }
        public string avatarURl { get; set; } = "Unknown";
        public string Description { get; set; } = "Unknown";

        public ICollection<Article>? Articles { get; set; }

    }
}
