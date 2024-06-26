namespace MinimalAPI.Dtos
{
    public class CreateArticleDTO
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class UpdateArticleDTO
    { 
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
