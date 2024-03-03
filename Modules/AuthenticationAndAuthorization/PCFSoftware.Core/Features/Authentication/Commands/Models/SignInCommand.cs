
using MediatR;
using Broker.AuthenticationAndAuthorization.Data.Results;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
