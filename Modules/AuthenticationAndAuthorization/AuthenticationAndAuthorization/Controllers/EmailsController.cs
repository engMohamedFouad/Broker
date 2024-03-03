using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Broker.AuthenticationAndAuthorization.Core.Features.Emails.Commands.Models;
using Broker.Common.AppMetaData;
using Broker.Common.Base;

namespace Broker.AuthenticationAndAuthorization.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "AuthenticationAndAuthorization")]
    [Authorize(Roles = "Admin,User")]
    public class EmailsController : AppControllerBase
    {
        [HttpPost(Router.AuthenticationAndAuthorization.EmailsRoute.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
