using Domain.Common;
using Domain.Enums;
using System.Linq.Expressions;

namespace Domain.Models
{
    public class Post : EntityBase
    {
        public Post() => Expression.Empty();

        public Post(string title, string shortDescription, string fullPost, Category? category)
        {
            Title = title;
            ShortDescription = shortDescription;
            FullPost = fullPost;
            Category = category ?? Category.SemCategoria;
        }

        public string Title { get; private set; } = null!;
        public string ShortDescription { get; private set; } = null!;
        public string FullPost { get; private set; } = null!;
        public Category Category { get; private set; }

        public void Edit(string title, string shortDescription, string fullPost, Category category)
        {
            Title = title;
            ShortDescription = shortDescription;
            FullPost = fullPost;
            Category = category;
        }
    }
}