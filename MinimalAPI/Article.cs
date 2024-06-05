namespace MinimalAPI
{
    public class Article
    {
        public DateTime createdAt { get; set; } = DateTime.Now;
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public string? Tags { get; set; }
        public User? User { get; set; }
        public Guid? userId { get; set; }

    }
}
