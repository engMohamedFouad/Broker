using MediatR;
using Broker.AuthenticationAndAuthorization.Data.Results;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
