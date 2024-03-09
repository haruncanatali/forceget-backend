using FORCEGET.Application.Auth.Queries.Login;
using FORCEGET.Application.Auth.Queries.Login.Dtos;
using FORCEGET.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FORCEGET.Api.Controllers;

[AllowAnonymous]
public class AuthController : BaseController
{
    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<BaseResponseModel<LoginDto>>> Login([FromBody] LoginCommand loginModel)
    {
        BaseResponseModel<LoginDto> loginResponse = await Mediator.Send(loginModel);
        return Ok(loginResponse);
    }
}