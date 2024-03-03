using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Commands.Models;
using Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Quaries.Models;
using Broker.Common.AppMetaData;
using Broker.Common.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Broker.AuthenticationAndAuthorization.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiExplorerSettings(GroupName = "AuthenticationAndAuthorization")]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.AuthenticationAndAuthorization.AuthorizationRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPost(Router.AuthenticationAndAuthorization.AuthorizationRouting.Edit)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.AuthenticationAndAuthorization.AuthorizationRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(id));
            return NewResult(response);
        }
        [HttpGet(Router.AuthenticationAndAuthorization.AuthorizationRouting.RoleList)]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await Mediator.Send(new GetRolesListQuery());
            return NewResult(response);
        }
        [SwaggerOperation(Summary = "idالصلاحية عن طريق ال", OperationId = "RoleById")]
        [HttpGet(Router.AuthenticationAndAuthorization.AuthorizationRouting.GetRoleById)]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetRoleByIdQuery() { Id = id });
            return NewResult(response);
        }
        [SwaggerOperation(Summary = " ادارة صلاحيات المستخدمين", OperationId = "ManageUserRoles")]
        [HttpGet(Router.AuthenticationAndAuthorization.AuthorizationRouting.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int userId)
        {
            var response = await Mediator.Send(new ManageUserRolesQuery() { UserId = userId });
            return NewResult(response);
        }
        [SwaggerOperation(Summary = " تعديل صلاحيات المستخدمين", OperationId = "UpdateUserRoles")]
        [HttpPut(Router.AuthenticationAndAuthorization.AuthorizationRouting.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [SwaggerOperation(Summary = " ادارة صلاحيات الاستخدام المستخدمين", OperationId = "ManageUserClaims")]
        [HttpGet(Router.AuthenticationAndAuthorization.AuthorizationRouting.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] int userId)
        {
            var response = await Mediator.Send(new ManageUserClaimsQuery() { UserId = userId });
            return NewResult(response);
        }
        [SwaggerOperation(Summary = " تعديل صلاحيات  الاستخدام المستخدمين", OperationId = "UpdateUserClaims")]
        [HttpPut(Router.AuthenticationAndAuthorization.AuthorizationRouting.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = " ادارة صلاحيات الاستخدام لمجموعات الصلاحيات", OperationId = "ManageRoleClaims")]
        [HttpGet(Router.AuthenticationAndAuthorization.AuthorizationRouting.ManageRoleClaims)]
        public async Task<IActionResult> ManageRoleClaims([FromRoute] int roleId)
        {
            var response = await Mediator.Send(new ManageRoleClaimsQuery() { RoleId = roleId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = " تعديل صلاحيات الاستخدام لمجموعات الصلاحيات", OperationId = "UpdateRoleClaims")]
        [HttpPut(Router.AuthenticationAndAuthorization.AuthorizationRouting.UpdateRoleClaims)]
        public async Task<IActionResult> UpdateRoleClaims([FromBody] UpdateRoleClaimsCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
