using Api.Controllers.v1.Base;
using Application.Dtos.Posts;
using Application.Interfaces;
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

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost()
        {
            var result = await _postService.CreatePost();

            if (!result.Success && result.StatusCode == 400)
                return BadRequest(false);
            else if (!result.Success && result.StatusCode == 500)
                return StatusCode(500);

            return Ok(result.Data);
        }

        [HttpPatch]
        public async Task<ActionResult<PostDto>> UpdatePost()
        {
            var result = await _postService.UpdatePost();

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