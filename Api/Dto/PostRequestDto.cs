using Domain.Enums;

namespace Api.Dto
{
    public class CreatePostRequestDto
    {
        public CreatePostRequestDto(string title, string shortDescription, string fullPost, Category? category)
        {
            Title = title;
            ShortDescription = shortDescription;
            FullPost = fullPost;
            Category = category;
        }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullPost { get; set; }
        public Category? Category { get; set; }
    }

    public class UpdatePostDto
    {
        public UpdatePostDto(Guid postId, string title, string shortDescription, string fullPost, Category category)
        {
            PostId = postId;
            Title = title;
            ShortDescription = shortDescription;
            FullPost = fullPost;
            Category = category;
        }

        public Guid PostId { get; set; }
        public string Title {  get; set; }
        public string ShortDescription { get; set; }
        public string FullPost { get; set; }
        public Category Category { get; set; }
    }
}