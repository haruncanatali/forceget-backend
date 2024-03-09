using FORCEGET.Application.Common.Models;
using FORCEGET.Application.CommonValues.Queries.GetCommonValues;
using Microsoft.AspNetCore.Mvc;

namespace FORCEGET.Api.Controllers;

public class CommonValuesController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<BaseResponseModel<GetCommonValuesVm>>> GetGenders()
    {
        return Ok(await Mediator.Send(new GetCommonValuesQuery()));
    }
}