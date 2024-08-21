using Application.Common.Mappings;
using Domain.Enums;
using Domain.Models;

namespace Application.Dtos.Posts
{
    public class PostDto : IMapFrom<Post>
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string FullPost { get; set; } = string.Empty;
        public Category Category { get; set; }
    }
}