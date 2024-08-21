using Domain.Common;
using Domain.Enums;
using System.Linq.Expressions;

namespace Domain.Models
{
    public class Post : EntityBase
    {
        public Post() => Expression.Empty();

        public Post(string title, string shortDescription, string fullPost, Category category)
        {
            Title = title;
            ShortDescription = shortDescription;
            FullPost = fullPost;
            Category = category;
        }

        public string Title { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string FullPost { get; set; } = null!;
        public Category Category { get; set; }
        public int Likes { get; set; }

        public void Like() => Likes++;
        public void Edit(string title, string shortDescription, string fullPost, Category category)
        {
            Title = title;
            ShortDescription = shortDescription;
            FullPost = fullPost;
            Category = category;
        }
    }
}