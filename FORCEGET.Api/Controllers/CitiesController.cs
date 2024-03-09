using FORCEGET.Application.Cities.Commands.Create;
using FORCEGET.Application.Cities.Commands.Delete;
using FORCEGET.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FORCEGET.Api.Controllers;

public class CitiesController : BaseController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreateCityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        return Ok(await Mediator.Send(new DeleteCityCommand() { Id = id }));
    }
}