using Domain.Enums;

namespace Api.Dto
{
    public class CreatePostDto(string title, string shortDescription, string fullPost, Category? category)
    {
        public string Title = title;
        public string ShortDescription = shortDescription;
        public string FullPost = fullPost;
        public Category? Category = category;
    }

    public class UpdatePostDto(string title, string shortDescription, string fullPost, Category category, Guid postId)
    {
        public string Title = title;
        public string ShortDescription = shortDescription;
        public string FullPost = fullPost;
        public Category Category = category;
        public Guid PostId = postId;
    }
}