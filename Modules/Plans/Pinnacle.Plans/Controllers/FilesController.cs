using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.File.Commands.Models;
using Pinnacle.Plans.Core.Features.File.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class FilesController : AppControllerBase
    {
        [HttpGet(Router.Plans.FilesRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetFilesOfPlanQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.FilesRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetFileByIdQuery() { Id=id }));

        }
        [HttpPost(Router.Plans.FilesRouting.Add)]
        public async Task<IActionResult> Add([FromForm] AddFilesToPlanCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.FilesRouting.Update)]
        public async Task<IActionResult> Update([FromForm] UpdateFilesToPlanCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.FilesRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteFilesToPlanCommand() { Id=id }));
        }
    }
}
