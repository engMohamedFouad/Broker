using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Models;
using Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "Plans")]
    public class ReviewPointsController : AppControllerBase
    {
        [HttpGet(Router.Plans.ReviewPointsRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetReviewPointsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.ReviewPointsRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetReviewPointByIdQuery() { Id = id }));
        }
        [HttpPost(Router.Plans.ReviewPointsRouting.Add)]
        public async Task<IActionResult> Add([FromForm] AddReviewPointsCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.ReviewPointsRouting.Update)]
        public async Task<IActionResult> Update([FromForm] UpdateReviewPointsCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.ReviewPointsRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteReviewPointsCommand() { Id = id }));
        }
    }
}
