using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.Reviews.Commands.Models;
using Pinnacle.Plans.Core.Features.Reviews.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class ReviewController : AppControllerBase
    {
        [HttpGet(Router.Plans.ReviewRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetReviewPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.ReviewRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetReviewByIdQuery() { Id = id }));
        }
        [HttpPost(Router.Plans.ReviewRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddReviewCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.ReviewRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateReviewCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.ReviewRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteReviewCommand() { Id=id }));
        }
    }
}
