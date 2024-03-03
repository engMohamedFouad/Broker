using MediatR;
using Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Quaries.Results;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Quaries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
    {
        public int Id { get; set; }
    }
}
