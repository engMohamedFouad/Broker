using Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Commands.Models;
using Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Models;
using Broker.Common.AppMetaData;
using Broker.Common.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Broker.AuthenticationAndAuthorization.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "AuthenticationAndAuthorization")]
    [Authorize(Roles = "Admin,User")]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.AuthenticationAndAuthorization.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.AuthenticationAndAuthorization.ApplicationUserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.AuthenticationAndAuthorization.ApplicationUserRouting.GetByID)]
        public async Task<IActionResult> GetStudentByID([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetUserByIdQuery(id)));
        }
        [HttpPut(Router.AuthenticationAndAuthorization.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.AuthenticationAndAuthorization.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new DeleteUserCommand(id)));
        }
        [HttpPut(Router.AuthenticationAndAuthorization.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
