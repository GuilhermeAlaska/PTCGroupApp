using Domain.Enums;

namespace Application.Dtos.Posts
{
    public class PostDto
    {
        public PostDto(Guid id, DateTime createdAt, string title, string shortDescription, string fullPost, Category category)
        {
            Id = id;
            CreatedAt = createdAt;
            Title = title;
            ShortDescription = shortDescription;
            FullPost = fullPost;
            Category = category.ToString();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string FullPost { get; set; } = string.Empty;
        public string Category { get; set; }
    }
}