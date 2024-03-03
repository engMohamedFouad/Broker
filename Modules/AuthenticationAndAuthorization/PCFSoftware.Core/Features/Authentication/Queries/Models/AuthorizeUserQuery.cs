using MediatR;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authentication.Queries.Models
{
    public class AuthorizeUserQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
