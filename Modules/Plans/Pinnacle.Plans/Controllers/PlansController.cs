using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.Plans.Commands.Models;
using Pinnacle.Plans.Core.Features.Plans.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "Plans")]
    public class PlansController : AppControllerBase
    {
        [HttpGet(Router.Plans.PlansRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetPlansPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.PlansRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetPlanByIdQuery() { Id=id }));
        }
        [HttpGet(Router.Plans.PlansRouting.GetMaxId)]
        public async Task<IActionResult> GetMaxId()
        {
            return NewResult(await Mediator.Send(new GetMaxIdQuery()));
        }
        [HttpPost(Router.Plans.PlansRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddPlansCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.PlansRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdatePlansCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.PlansRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeletePlanCommand() { Id=id }));
        }
    }
}
