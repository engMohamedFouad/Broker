using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.Indicators.Commands.Models;
using Pinnacle.Plans.Core.Features.Indicators.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class IndicatorController : AppControllerBase
    {
        [HttpGet(Router.Plans.IndicatorRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetIndicatorPaginationQuary query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.IndicatorRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetIndicatorByIdQuery() { Id = id }));
        }
        [HttpPost(Router.Plans.IndicatorRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddIndicatorCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.IndicatorRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateIndicatorCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.IndicatorRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteIndicatorCommand() { Id=id }));
        }
    }
}