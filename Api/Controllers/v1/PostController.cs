using Api.Controllers.v1.Base;
using Api.Dto;
using Application.Dtos.Posts;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<PostDto> GetPostById([FromRoute] Guid id)
        {
            return await _postService.GetPostById(id);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<PostDto>> GetAllPosts()
        {
            return await _postService.GetAllPosts();
        }

        [AllowAnonymous]
        [HttpGet("category/{category}")]
        public async Task<List<PostDto>> GetPostsByCategory([FromRoute] Category category)
        {
            return await _postService.GetPostsByCategory(category);
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto request)
        {
            var result = await _postService.CreatePost(request.Title, request.ShortDescription, request.FullPost, request.Category);

            if (!result.Success && result.StatusCode == 400)
                return BadRequest(false);
            else if (!result.Success && result.StatusCode == 500)
                return StatusCode(500);

            return Ok(result.Data);
        }

        [HttpPatch]
        public async Task<ActionResult<PostDto>> UpdatePost(UpdatePostDto request)
        {
            var result = await _postService.UpdatePost(request.PostId, request.Title, request.ShortDescription, request.FullPost, request.Category);

            if (!result.Success && result.StatusCode == 400)
                return BadRequest(false);
            else if (!result.Success && result.StatusCode == 500)
                return StatusCode(500);

            return Ok(result.Data);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeletePost([FromRoute] Guid id)
        {
            var result = await _postService.DeletePost(id);

            if (!result.Success && result.StatusCode == 400)
                return BadRequest(false);
            else if (!result.Success && result.StatusCode == 500)
                return StatusCode(500);

            return Ok();
        }
    }
}