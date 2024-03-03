using Broker.AuthenticationAndAuthorization.Core.Features.Authentication.Commands.Models;
using Broker.AuthenticationAndAuthorization.Core.Features.Authentication.Queries.Models;
using Broker.Common.AppMetaData;
using Broker.Common.Base;
using Microsoft.AspNetCore.Mvc;

namespace Broker.AuthenticationAndAuthorization.Api.Controllers
{

    [ApiExplorerSettings(GroupName = "AuthenticationAndAuthorization")]
    public class AuthenticationController : AppControllerBase
    {

        [HttpPost(Router.AuthenticationAndAuthorization.Authentication.SignIn)]
        public async Task<IActionResult> Create([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Router.AuthenticationAndAuthorization.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.AuthenticationAndAuthorization.Authentication.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpGet(Router.AuthenticationAndAuthorization.Authentication.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpPost(Router.AuthenticationAndAuthorization.Authentication.SendResetPasswordCode)]
        public async Task<IActionResult> SendResetPassword([FromQuery] SendResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.AuthenticationAndAuthorization.Authentication.ConfirmResetPasswordCode)]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmResetPasswordQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpPost(Router.AuthenticationAndAuthorization.Authentication.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
