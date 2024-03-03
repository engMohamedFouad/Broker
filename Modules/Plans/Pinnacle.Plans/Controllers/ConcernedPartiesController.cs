using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Models;
using Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "Plans")]
    public class ConcernedPartiesController : AppControllerBase
    {
        [HttpGet(Router.Plans.ConcernedPartiesRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetConcernedPartiesPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.ConcernedPartiesRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetConcernedPartiesByIdQuery() { Id = id }));
        }
        [HttpGet(Router.Plans.ConcernedPartiesRouting.GetMaxId)]
        public async Task<IActionResult> GetMaxId()
        {
            return NewResult(await Mediator.Send(new GetMaxIdQuery()));
        }
        // [Authorize(Policy = "Create ConcernedParty")]
        [HttpPost(Router.Plans.ConcernedPartiesRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddConcernedPartiesCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        //[Authorize(Policy = "Update ConcernedParty")]
        [HttpPut(Router.Plans.ConcernedPartiesRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateConcernedPartiesCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        // [Authorize(Policy = "Delete ConcernedParty")]
        [HttpDelete(Router.Plans.ConcernedPartiesRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteConcernedPartiesCommand() { Id = id }));
        }
    }
}
