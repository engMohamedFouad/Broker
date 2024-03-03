using MediatR;
using Broker.AuthenticationAndAuthorization.Data.Results;
using Broker.Core.Bases;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {
        public int UserId { get; set; }
    }
}
