using Application.Dtos.Posts;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        public void CreatePost()
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PostDto> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public PostDto? GetPostById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(PostDto post)
        {
            throw new NotImplementedException();
        }
    }
}