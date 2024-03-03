using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.UserPoints.Commands.Models;
using Pinnacle.Plans.Core.Features.UserPoints.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class UserPointController : AppControllerBase
    {
        [HttpGet(Router.Plans.UserPointRouting.GetUsersByPointId)]
        public async Task<IActionResult> GetById([FromRoute] int pointId)
        {
            return NewResult(await Mediator.Send(new GetUsersAssignedByPointIdQuery() { PointId = pointId }));

        }
        [HttpPost(Router.Plans.UserPointRouting.Add)]
        public async Task<IActionResult> Add([FromForm] AddUserPointCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.UserPointRouting.Delete)]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserPointCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
