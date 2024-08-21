using Api.Controllers.v1.Base;
using Application.Common.Interfaces;
using Application.Interfaces;

namespace Api.Controllers.v1
{
    public class AccountController(IJwtService jwtService, IUserService userService) : BaseController
    {
        //[HttpPost("new-password")]
        //public async Task<ActionResult> CreateNewPassword(NewPasswordDto newPasswordDto)
        //{
        //    var isValid = await jwtService.ValidPasswordToken(newPasswordDto.Token);
        //    if (!isValid)
        //        return BadRequest();

        //    var handler = new JwtSecurityTokenHandler();
        //    var jsonToken = handler.ReadToken(newPasswordDto.Token);

        //    if (jsonToken is not JwtSecurityToken token)
        //        return Unauthorized();

        //    var userId = new Guid(token.Claims.First(claim => claim.Type == "sub").Value);

        //    var result = await userService.UpdatePassword

        //    var command = new UpdatePasswordCommand
        //    {
        //        Password = newPasswordDto.Password,
        //        RePassword = newPasswordDto.RePassword,
        //        UserId = userId
        //    };

        //    return Ok(await Mediator.Send(command));
        //}
    }
}