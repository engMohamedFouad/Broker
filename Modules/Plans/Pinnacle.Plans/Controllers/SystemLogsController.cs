using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.SystemLogs.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class SystemLogsController : AppControllerBase
    {
        [HttpGet(Router.Plans.SystemLogsRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetSystemLogsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
