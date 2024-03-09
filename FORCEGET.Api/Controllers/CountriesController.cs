using FORCEGET.Application.Common.Models;
using FORCEGET.Application.Countries.Commands.Create;
using FORCEGET.Application.Countries.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FORCEGET.Api.Controllers;

public class CountriesController : BaseController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreateCountryCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Delete(long id)
    {
        return Ok(await Mediator.Send(new DeleteCountryCommand { Id = id }));
    }
}