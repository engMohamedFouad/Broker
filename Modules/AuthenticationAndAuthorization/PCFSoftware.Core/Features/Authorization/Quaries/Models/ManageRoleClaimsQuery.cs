using MediatR;
using Broker.AuthenticationAndAuthorization.Data.Results;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Quaries.Models
{
    public class ManageRoleClaimsQuery : IRequest<Response<ManageRoleClaimsResult>>
    {
        public int RoleId { get; set; }
    }
}
