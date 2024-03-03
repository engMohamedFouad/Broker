using Microsoft.AspNetCore.Mvc;
using Pinnacle.Common.AppMetaData;
using Pinnacle.Common.Base;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Models;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Models;

namespace Pinnacle.Plans.Controllers
{
    [ApiExplorerSettings(GroupName = "Plans")]
    public class IndicatorsCategoriesController : AppControllerBase
    {
        [HttpGet(Router.Plans.IndicatorsCategoriesRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetIndicatorsCategoriesPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.Plans.IndicatorsCategoriesRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetIndicatorsCategoriesByIdQuery() { Id = id }));
        }
        [HttpPost(Router.Plans.IndicatorsCategoriesRouting.Add)]
        public async Task<IActionResult> Add([FromBody] AddIndicatorsCategoriesCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.Plans.IndicatorsCategoriesRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateIndicatorsCategoriesCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.Plans.IndicatorsCategoriesRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteIndicatorsCategoriesCommand() { Id=id }));
        }
    }
}
