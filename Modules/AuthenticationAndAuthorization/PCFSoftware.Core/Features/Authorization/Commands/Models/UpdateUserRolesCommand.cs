using MediatR;
using Broker.AuthenticationAndAuthorization.Data.DTOs;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesRequest, IRequest<Response<string>>
    {
    }
}
