using Api.Controllers.v1.Base;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    public class AccountController : BaseController
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}