using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.Managements.Commands.Models;
using Pinnacle.Plans.Core.Features.Managements.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class ManagementController : AppControllerBase
    {
        [HttpGet(Router.Plans.ManagementRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetManagementsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.ManagementRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetManagementByIdQuery() { Id = id }));
        }
        [HttpPost(Router.Plans.ManagementRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddManagementCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.ManagementRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateManagementCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.ManagementRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteManagementCommand() { Id=id }));
        }
    }
}
