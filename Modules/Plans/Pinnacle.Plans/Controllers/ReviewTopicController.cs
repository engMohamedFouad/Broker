using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Models;
using Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class ReviewTopicController : AppControllerBase
    {
        [HttpGet(Router.Plans.ReviewTopicRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetReviewTopicsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.ReviewTopicRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetReviewTopicsByIdQuery() { Id = id }));
        }
        [HttpPost(Router.Plans.ReviewTopicRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddReviewTopicsCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.ReviewTopicRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateReviewTopicsCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.ReviewTopicRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteReviewTopicsCommand() { Id=id }));
        }
    }
}
