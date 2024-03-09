using FORCEGET.Application.Common.Models;
using FORCEGET.Application.Offers.Commands.Create;
using FORCEGET.Application.Offers.Queries.GetOffers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FORCEGET.Api.Controllers;

public class OffersController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetOffersVm>>> List([FromQuery] int page = 1, int pageSize = 10)
    {
        return Ok(await Mediator.Send(new GetOffersQuery
        {
            Page = page,
            PageSize = pageSize
        }));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BaseResponseModel<Unit>>> Create([FromBody] CreateOfferCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}