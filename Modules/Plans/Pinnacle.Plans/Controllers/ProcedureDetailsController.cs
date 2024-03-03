using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Commands.Models;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "Plans")]
    public class ProcedureDetailsController : AppControllerBase
    {
        [HttpGet(Router.Plans.ProcedureDetailsRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetProcedureDetailsPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.ProcedureDetailsRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetProcedureDetailsByIdQuery() { Id = id }));
        }

        [HttpPost(Router.Plans.ProcedureDetailsRouting.Add)]
        public async Task<IActionResult> Add([FromForm] AddProcedureDetailsCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpPut(Router.Plans.ProcedureDetailsRouting.Update)]
        public async Task<IActionResult> Update([FromForm] UpdateProcedureDetailsCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.ProcedureDetailsRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteProcedureDetailsCommand() { Id = id }));
        }
    }
}
