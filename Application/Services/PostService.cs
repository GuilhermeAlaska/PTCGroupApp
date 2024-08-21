using Application.Common;
using Application.Dtos.Posts;
using Application.Interfaces;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        public Task<BaseResult<PostDto>> CreatePost()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<PostDto>> DeletePost(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostDto>> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetPostById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostDto>> GetPostsByCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<PostDto>> UpdatePost()
        {
            throw new NotImplementedException();
        }
    }
}