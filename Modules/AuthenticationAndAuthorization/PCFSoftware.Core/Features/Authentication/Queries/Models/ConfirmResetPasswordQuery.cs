using MediatR;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authentication.Queries.Models
{
    public class ConfirmResetPasswordQuery : IRequest<Response<string>>
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
