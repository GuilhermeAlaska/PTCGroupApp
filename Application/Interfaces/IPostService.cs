﻿using Application.Common;
using Application.Dtos.Posts;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IPostService
    {
        public Task<PostDto> GetPostById(Guid id);
        public Task<List<PostDto>> GetAllPosts();
        public Task<List<PostDto>> GetPostsByCategory(Category category);
        public Task<BaseResult<PostDto>> CreatePost();
        public Task<BaseResult<PostDto>> UpdatePost();
        public Task<BaseResult<PostDto>> DeletePost(Guid id);
    }
}