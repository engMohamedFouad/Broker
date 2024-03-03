using MediatR;
using Broker.AuthenticationAndAuthorization.Data.Requests;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand : UpdateUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
