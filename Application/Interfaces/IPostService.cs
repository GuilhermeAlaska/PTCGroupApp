using Application.Common;
using Application.Dtos.Posts;
using Domain.Enums;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IPostService
    {
        public Task<PostDto> GetPostById(Guid id);
        public Task<List<PostDto>> GetAllPosts();
        public Task<List<Post>> GetAllPosts2();
        public Task<List<PostDto>> GetPostsByCategory(Category category);
        public Task<BaseResult<PostDto>> CreatePost(string title, string shortDescription, string fullPost, Category? category);
        public Task<BaseResult<PostDto>> UpdatePost(Guid postId, string title, string shortDescription, string fullPost, Category category);
        public Task<BaseResult<PostDto>> DeletePost(Guid id);
    }
}