using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.Procedures.Commands.Models;
using Pinnacle.Plans.Core.Features.Procedures.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "Plans")]
    public class ProcedureController : AppControllerBase
    {
        [HttpGet(Router.Plans.ProcedureRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetProcedurePaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.ProcedureRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetProcedureByIdQuery() { Id = id }));
        }
        [HttpPost(Router.Plans.ProcedureRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddProcedureCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.ProcedureRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateProcedureCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.ProcedureRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteProcedureCommand() { Id = id }));
        }
    }
}
