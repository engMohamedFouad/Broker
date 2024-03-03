using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Models;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class FirstlyDataController : AppControllerBase
    {
        [HttpGet(Router.Plans.FirstlyDataRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetFirstlyDataQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.FirstlyDataRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetFirstlyDataByIdQuery() { Id=id }));
        }
        [HttpPost(Router.Plans.FirstlyDataRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddFirstlyDataCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.FirstlyDataRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateFirstlyDataCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.FirstlyDataRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteFirstlyDataCommand() { Id=id }));
        }
    }
}
