using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.Branches.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "Plans")]
    public class BranchController : AppControllerBase
    {
        [HttpGet(Router.Plans.BranchRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetBranchesByConcernedPartyQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }

}
