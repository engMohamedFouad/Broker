using MediatR;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authentication.Commands.Models
{
    public class SendResetPasswordCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
