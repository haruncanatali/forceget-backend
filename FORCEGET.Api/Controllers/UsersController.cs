using FORCEGET.Application.Common.Models;
using FORCEGET.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FORCEGET.Api.Controllers;

public class UsersController : BaseController
{
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<long>>> Create([FromBody] CreateUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}