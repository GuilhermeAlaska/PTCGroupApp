using Api.Controllers.v1.Base;
using Api.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    public class AccountController(IUserService userService) : BaseController
    {
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            var result = await userService.SignIn(request.Email, request.Password);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await userService.CreateUser(request.Name, request.Email, request.Password);

            if (result.Success)
            {
                return CreatedAtAction("CreateUser", result);
            }

            return BadRequest(result);
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserRequest request)
        {
            var result = await userService.UpdateUser(userId, request.Name, request.Email);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
        {
            var result = await userService.UpdatePassword(request.Password, request.ActualPassword, request.UserId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await userService.DeleteUser(userId);

            if (result.Success)
            {
                return NoContent();
            }

            return BadRequest(result);
        }
    }
}