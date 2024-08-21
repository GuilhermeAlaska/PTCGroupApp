using Application.Common;
using Application.Dtos.Posts;

namespace Application.Interfaces
{
    public interface IPostService
    {
        public Task<PostDto> GetPostById(Guid id);
        public Task<List<PostDto>> GetAllPosts();
        public Task<BaseResult<PostDto>> CreatePost();
        public Task<BaseResult<PostDto>> UpdatePost();
        public Task<BaseResult<PostDto>> DeletePost(Guid id);
    }
}