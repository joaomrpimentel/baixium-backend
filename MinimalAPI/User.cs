namespace MinimalAPI
{
    public class User
    {
        public DateTime createdAt = DateTime.Now;
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean isAdmin { get; set; }
        public string avatarURl { get; set; }
        public string Description { get; set; }

        public ICollection<Article>? Articles { get; set; }

    }
}
