using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.PointComments.Commands.Models;
using Pinnacle.Plans.Core.Features.PointComments.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class PointCommentsController : AppControllerBase
    {
        [HttpGet(Router.Plans.PointCommentsRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromRoute] int pointId)
        {
            var response = await Mediator.Send(new GetPointsCommentsQuery() { PointId = pointId });
            return Ok(response);
        }
        [HttpGet(Router.Plans.PointCommentsRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetPointsCommentsByIdQuery() { Id = id }));

        }
        [HttpPost(Router.Plans.PointCommentsRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddPointCommentsCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.PointCommentsRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdatePointCommentsCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.PointCommentsRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeletePointCommentsCommand() { Id = id }));
        }
    }
}
