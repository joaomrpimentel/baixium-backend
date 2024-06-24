namespace MinimalAPI.Models
{
    public class Article
    {
        public DateTime createdAt { get; set; } = DateTime.Now;
        public Guid Id { get; set; }
        public string Title { get; set; } = "Unknown";
        public string Content { get; set; } = "Unknown";
        public int Likes { get; set; }
        public string? Tags { get; set; }
        public User? User { get; set; }
        public string userId { get; set; } = "Unknowm";

    }
}
