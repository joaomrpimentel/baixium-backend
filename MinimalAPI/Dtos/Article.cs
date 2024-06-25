namespace MinimalAPI.Dtos
{
    public class CreateArticleDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
